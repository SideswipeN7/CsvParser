using System.IO;
using System.Linq;
using System.Reflection;
using CsvParser.Builders;
using CsvParser.Interfaces;
using CsvParser.Test.Models;
using NUnit.Framework;

namespace CsvParser.Test
{
    public class Tests
    {
        public static string[] csvFileLines;

        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\Data\correct_data.csv");
            csvFileLines = File.ReadAllLines(path);
        }

        [Test]
        public void Test1()
        {
            var parser = BuildParser();

            var result = parser.Parse(csvFileLines);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Luke", result.ElementAt(0).Name);
        }

        private static ICsvModelParser<ForceWielder> BuildParser() => CsvParserBuilder<ForceWielder>.Init()
                                                                                                    .Build();
    }
}