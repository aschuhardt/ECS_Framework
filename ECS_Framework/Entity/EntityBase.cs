using System;

namespace ECS_Framework.Entity
{
    public abstract class EntityBase : IEntity
    {
        public Guid ID { get; set; }

        public Type[] ComponentsTypes => Components();

        protected abstract Type[] Components();

        public EntityBase()
        {
            ID = Guid.NewGuid();
        }
    }
}
