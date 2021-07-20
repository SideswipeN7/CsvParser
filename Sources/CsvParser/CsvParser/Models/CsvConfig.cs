using System;
using CsvParser.Constants;

namespace CsvParser.Models
{
    public class CsvConfig
    {
        public static readonly CsvConfig Default = new()
        {
            Separator = Separators.Coma,
            IsFirstLineTitle = true,
            OnParseErrorAction = null,
            ShouldThrowOnException = true,
        };
        public string Separator { get; set; } = default!;

        public bool IsFirstLineTitle { get; set; }

        public bool ShouldThrowOnException { get; set; }

        public Action<OnErrorModel>? OnParseErrorAction { get; set; }

        public CsvConfig()
        {
        }

        public CsvConfig(CsvConfig config)
        {
            Separator = config.Separator;
            IsFirstLineTitle = config.IsFirstLineTitle;
            ShouldThrowOnException = config.ShouldThrowOnException;
            Separator = new string(config.Separator);
            OnParseErrorAction = config.OnParseErrorAction?.Clone() as Action<OnErrorModel>;
        }
    }
}