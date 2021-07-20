using System;

namespace CsvParser.Models
{
    public record OnErrorModel(int LineIndex, string Line, Exception Exception);
}