using System.Collections.Generic;

namespace CsvParser.Interfaces
{
    public interface ICsvModelParser<T> where T : ICsvModel, new()
    {
        IEnumerable<T> Parse(string data);

        IEnumerable<T> Parse(string[] data);
    }
}