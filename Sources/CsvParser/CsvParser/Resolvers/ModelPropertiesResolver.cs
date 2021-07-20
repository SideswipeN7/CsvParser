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
        internal static IList<PropertyModel> Resolve<T>() where T : ICsvModel => typeof(T).GetProperties()
                                                                                         .Where(CheckHasProperty)
                                                                                         .Select(SelectModel)
                                                                                         .OrderBy(OrderByIndex)
                                                                                         .ToList();
        private static bool CheckHasProperty(PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<CsvParseAttribute>(false) is not null;
        private static PropertyModel SelectModel(PropertyInfo propertyInfo) => new(GetPropertyOrder(propertyInfo), propertyInfo);
        private static int GetPropertyOrder(PropertyInfo propertyInfo) => GetPropertyOrderAttribute(propertyInfo).Order;
        private static CsvParseAttribute GetPropertyOrderAttribute(PropertyInfo propertyInfo) => propertyInfo.GetCustomAttributes<CsvParseAttribute>(false).Single();
        private static int OrderByIndex(PropertyModel propertyModel) => propertyModel.Index;
    }
}