using System;

namespace CsvParser.Resolvers
{
    internal static class NullableTypeValueResolver
    {
        public static object? GetValue(Type type, string value)
        {
            return type.FullName switch
            {
                string name when name.Contains(nameof(Int16)) => ParseNullableInt16(value),
                string name when name.Contains(nameof(Int32)) => ParseNullableInt32(value),
                string name when name.Contains(nameof(Int64)) => ParseNullableInt64(value),
                string name when name.Contains(nameof(Decimal)) => ParseNullableDecimal(value),
                string name when name.Contains(nameof(Double)) => ParseNullableDouble(value),
                string name when name.Contains(nameof(Boolean)) => ParseNullableBool(value),
                string name when name.Contains(nameof(Byte)) => ParseNullableByte(value),
                string name when name.Contains(nameof(Guid)) => ParseNullableGuid(value),
                _ => value,
            };
        }

        private static short? ParseNullableInt16(string value)
        {
            var isValid = short.TryParse(value, out short parsedValue);

            return isValid ? parsedValue : null;
        }

        private static int? ParseNullableInt32(string value)
        {
            var isValid = int.TryParse(value, out int parsedValue);

            return isValid ? parsedValue : null;
        }

        private static long? ParseNullableInt64(string value)
        {
            var isValid = long.TryParse(value, out long parsedValue);

            return isValid ? parsedValue : null;
        }

        private static decimal? ParseNullableDecimal(string value)
        {
            var isValid = decimal.TryParse(value, out decimal parsedValue);

            return isValid ? parsedValue : null;
        }

        private static double? ParseNullableDouble(string value)
        {
            var isValid = double.TryParse(value, out double parsedValue);

            return isValid ? parsedValue : null;
        }

        private static bool? ParseNullableBool(string value)
        {
            var isValid = bool.TryParse(value, out bool parsedValue);

            return isValid ? parsedValue : null;
        }

        private static byte? ParseNullableByte(string value)
        {
            var isValid = byte.TryParse(value, out byte parsedValue);

            return isValid ? parsedValue : null;
        }

        private static Guid? ParseNullableGuid(string value)
        {
            var isValid = Guid.TryParse(value, out Guid parsedValue);

            return isValid ? parsedValue : null;
        }
    }
}