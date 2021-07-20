using System;
using System.Collections.Generic;
using System.Linq;
using CsvParser.Interfaces;
using CsvParser.Models;
using CsvParser.Resolvers;

namespace CsvParser.Parsers
{
    internal class CsvModelParser<T> : ICsvModelParser<T> where T : ICsvModel, new()
    {
        private readonly IEnumerable<PropertyModel> properties;

        public CsvConfig Config { get; set; }

        public CsvModelParser(CsvConfig config)
        {
            Config = config;
            properties = ModelPropertiesResolver.Resolve<T>();
        }

        public IEnumerable<T> Parse(string csvFileContent) => Parse(csvFileContent.Split('\n'));

        public IEnumerable<T> Parse(string[] csvLines)
        {
            var models = new List<T>();
            var startIndex = GetStartIndex();

            for (int lineIndex = startIndex; lineIndex < csvLines.Length; ++lineIndex)
            {
                try
                {
                    var model = ParseLineToModel(csvLines[lineIndex]);

                    models.Add(model);
                }
                catch (Exception exception)
                {
                    Config.OnParseErrorAction?.Invoke(new(lineIndex, csvLines[lineIndex], exception));

                    if (Config.ShouldThrowOnException)
                    {
                        throw;
                    }
                }
            }

            return models;
        }

        private int GetStartIndex() => Config.IsFirstLineTitle ? 1 : 0;

        private T ParseLineToModel(string lineValue)
        {
            T model = new();

            var values = lineValue.Split(Config.Separator);

            for (int propertyIndex = 0; propertyIndex < values.Length; ++propertyIndex)
            {
                SetModelProperty(model, values, propertyIndex);
            }

            return model;
        }

        private void SetModelProperty(T model, string[] values, int propertyIndex)
        {
            var property = properties.FirstOrDefault(p => p.Index == propertyIndex);
            if (property is not null)
            {
                var value = TypeValueResolver.GetValue(property.PropertyInfo.PropertyType, values[propertyIndex]);

                property.PropertyInfo.SetValue(model, value);
            }
        }
    }
}