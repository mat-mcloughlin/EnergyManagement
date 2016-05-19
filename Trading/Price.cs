using System;

namespace Trading
{
    public class Price
    {
        public Price(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
            if (value <= 0 || string.IsNullOrWhiteSpace(currency))
            {
                throw new Exception("Deal ticket must have a price");
            }
        }

        public decimal Value { get; private set; }

        public string Currency { get; private set; }
    }
}