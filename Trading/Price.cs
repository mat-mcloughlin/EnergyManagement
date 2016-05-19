using System;

namespace Trading
{
    public class Price
    {
        public Price(decimal value, string currency)
        {
            if (value <= 0 || string.IsNullOrWhiteSpace(currency))
            {
                throw new Exception("A Price must have a value and currency");
            }

            Currency = currency;
            Value = value;
        }

        public decimal Value { get; private set; }

        public string Currency { get; private set; }
    }
}