using System;

namespace ECS_Framework.Component
{
    public interface IComponent
    {
        Guid EntityID { get; set; }
    }
}
