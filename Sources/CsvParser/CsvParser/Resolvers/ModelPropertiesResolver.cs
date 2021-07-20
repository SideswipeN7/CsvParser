using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CsvParser.Attributes;
using CsvParser.Interfaces;
using CsvParser.Models;

namespace CsvParser.Resolvers
{
    public static class ModelPropertiesResolver
    {
        internal static IList<PropertyModel> Resolve<T>() where T : CsvModel => typeof(T).GetProperties(BindingFlags.Public)
                                                                                         .Where(p => Attribute.IsDefined(p, typeof(CsvParseAttribute)))
                                                                                         .Select(p => new PropertyModel(GetPropertyOrder(p), p))
                                                                                         .OrderBy(p => p.Index)
                                                                                         .ToList();

        private static int GetPropertyOrder(PropertyInfo propertyInfo) => GetPropertyOrderAttribute(propertyInfo).Order;

        private static CsvParseAttribute GetPropertyOrderAttribute(PropertyInfo propertyInfo) => (CsvParseAttribute)propertyInfo.GetCustomAttributes(typeof(CsvParseAttribute), false).Single();
    }
}