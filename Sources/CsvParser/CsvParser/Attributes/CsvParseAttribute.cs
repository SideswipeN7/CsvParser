using System;

namespace CsvParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class CsvParseAttribute : Attribute
    {
        private readonly int order_;
        public CsvParseAttribute(int order)
        {
            order_ = order;
        }

        public int Order { get { return order_; } }
    }
}