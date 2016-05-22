using System.Collections.Generic;

namespace Infrastructure
{
    public class Entity
    {
        public ICollection<object> Events { get; internal set; }
    }
}
