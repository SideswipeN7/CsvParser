using System;

namespace CsvParser.Resolvers
{
    internal static class TypeValueResolver
    {
        public static object GetValue(Type type, string value)
        {
            return type.Name switch
            {
                "int" => int.Parse(value),
                "decimal" => decimal.Parse(value),
                "double" => decimal.Parse(value),
                "bool" => bool.Parse(value),
                _ => value,
            };
        }
    }
}