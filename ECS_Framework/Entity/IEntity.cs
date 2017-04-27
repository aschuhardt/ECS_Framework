using System;

namespace ECS_Framework.Entity
{
    public interface IEntity
    {
        Guid ID { get; set; }
        Type[] ComponentsTypes { get; }
    }
}
