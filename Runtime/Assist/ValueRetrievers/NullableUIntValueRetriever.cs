using System;
using System.Collections.Generic;

namespace TechTalk.SpecFlow.Assist.ValueRetrievers
{
    public class NullableUIntValueRetriever : IValueRetriever
    {
        private readonly Func<string, uint> uintValueRetriever = v => new UIntValueRetriever().GetValue(v);

        public NullableUIntValueRetriever(Func<string, uint> uintValueRetriever = null)
        {
            if (uintValueRetriever != null)
                this.uintValueRetriever = uintValueRetriever;
        }

        public uint? GetValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return uintValueRetriever(value);
        }

        public object ExtractValueFromRow(TableRow row, Type targetType)
        {
            return GetValue(row[1]);
        }

        public bool CanRetrieve(Type type)
        {
            return type == typeof(uint?);
        }
    }
}