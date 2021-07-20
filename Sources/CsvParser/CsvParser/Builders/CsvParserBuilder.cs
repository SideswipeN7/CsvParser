using System;
using CsvParser.Models;

namespace CsvParser.Builders
{
    public class CsvConfigBuilder
    {
        private CsvConfig config = new CsvConfig();

        private CsvConfigBuilder()
        {
        }

        public CsvConfig Build() => config;

        public static CsvConfigBuilder Init() => new CsvConfigBuilder();

        public CsvConfigBuilder SetSeparator(string separator)
        {
            config.Separator = separator;

            return this;
        }

        public CsvConfigBuilder SetIsFirstLineTitle(bool isFirstLineTitle)
        {
            config.IsFirstLineTitle = isFirstLineTitle;

            return this;
        }

        public CsvConfigBuilder SetShouldThrowOnException(bool shouldThrowOnException)
        {
            config.ShouldThrowOnException = shouldThrowOnException;

            return this;
        }

        public CsvConfigBuilder SetOnParseErrorAction(Action<OnErrorModel> onParseErrorAction)
        {
            config.OnParseErrorAction = onParseErrorAction;

            return this;
        }
    }
}