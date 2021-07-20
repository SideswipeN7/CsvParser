using CsvParser.Interfaces;
using CsvParser.Models;
using CsvParser.Parsers;

namespace CsvParser.Builders
{
    public class CsvParserBuilder<T> where T : ICsvModel, new()
    {
        private CsvModelParser<T> csvParser = new CsvModelParser<T>(new(CsvConfig.Default));

        private CsvParserBuilder()
        {
        }

        public ICsvModelParser<T> Build() => csvParser;

        public static CsvParserBuilder<T> Init() => new CsvParserBuilder<T>();

        public CsvParserBuilder<T> SetDefaultConfig() => SetConfig(new(CsvConfig.Default));

        public CsvParserBuilder<T> SetConfig(CsvConfig csvConfig)
        {
            csvParser.Config = csvConfig;

            return this;
        }
    }
}