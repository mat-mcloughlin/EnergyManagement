using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure
{
    public class Aggregate
    {
        public ICollection<object> Events = new LinkedList<object>();

        readonly IDictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();

        public Aggregate()
        {
            Register();
        }

        public Guid Id { get; set; }
        public int Version { get; internal set; }

        public void Apply(object @event)
        {
            _handlers[@event.GetType()](@event); 
        }

        public void Raise(object @event)
        {
            Apply(@event);
            Events.Add(@event);
        }

        void Register()
        {
            var applyMethods = GetType()
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name == "Apply")
                .Select(m => new
                {
                    Method = m,
                    MessageType = m.GetParameters().Single().ParameterType
                });

            foreach (var apply in applyMethods)
            {
                _handlers.Add(apply.MessageType, m => apply.Method.Invoke(this, new[] { m }));
            }
        }
    }
}