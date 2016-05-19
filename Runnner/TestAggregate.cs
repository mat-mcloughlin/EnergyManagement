using System;

namespace Runnner
{
    class TestAggregate : Aggregate
    {
        public TestAggregate(Guid id)
        {
            Id = id;
            Version = 1;
        }

        private TestAggregate()
        {
            
        }

        public void Do(string something)
        {
            Raise(new Done(something));
        }

        void Apply(Done @event)
        {
            this.Something = @event.Something;
        }

        public string Something { get; set; }
    }

    internal class Done
    {
        public string Something { get; set; }

        public Done(string something)
        {
            Something = something;
        }
    }
}
