using CsvParser.Attributes;
using CsvParser.Interfaces;

namespace CsvParser.Test.Models
{
    public class ForceWielder : ICsvModel
    {
        [CsvParse(0)]
        public string Name { get; set; }

        [CsvParse(1)]
        public int ForcePower { get; set; }

        [CsvParse(2)]
        public bool IsJedi { get; set; }

        [CsvParse(3)]
        public double Midichlorians { get; set; }
    }
}