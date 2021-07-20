using System;
using System.Globalization;

namespace CsvParser.Resolvers
{
    internal static class TypeValueResolver
    {
        public static object? GetValue(Type type, string value)
        {
            return type.Name switch
            {
                nameof(Int16) => short.Parse(value),
                nameof(Int32) => int.Parse(value),
                nameof(Int64) => long.Parse(value),
                nameof(Decimal) => decimal.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture),
                nameof(Double) => double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture),
                nameof(Boolean) => bool.Parse(value),
                nameof(Byte) => byte.Parse(value),
                nameof(Guid) => Guid.Parse(value),
                nameof(Nullable) => NullableTypeValueResolver.GetValue(type, value),
                _ => value,
            };
        }
    }
}