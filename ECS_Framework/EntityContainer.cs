using ECS_Framework.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECS_Framework
{
    public class EntityContainer
    {
        public Guid ID { get; }

        private IList<IComponent> _components;

        public EntityContainer(Guid id, IList<IComponent> components)
        {
            ID = id;
            _components = components;
        }

        public T GetComponent<T>() where T : IComponent
        {
            return _components.OfType<T>().First();
        }
    }
}
