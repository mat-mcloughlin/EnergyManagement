using System;

namespace Trading
{
    public class Amount
    {
        public Amount(int volume, string unit)
        {
            if (volume <= 0 || string.IsNullOrWhiteSpace(unit))
            {
                throw new Exception("An amount must have a volume and unit");
            }

            Volume = volume;
            Unit = unit;
        }

        public int Volume { get; private set; }

        public string Unit { get; private set; }
    }
}
