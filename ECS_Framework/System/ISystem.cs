using System;
using System.Collections.Generic;
using ECS_Framework.Component;

namespace ECS_Framework.System
{
    /// <summary>
    /// Initialization Systems will only be run when the entire 
    ///     framework is initializing -- a single time at the start of execution
    ///     
    /// Creation Systems will be run whenever a new Entity is created.
    /// 
    /// Iteration Systems will be run on each update of the container.
    /// </summary>
    public enum SystemType
    {
        Initialization,
        Creation,
        Iteration
    }

    public interface ISystem
    {
        ECSManager Manager { get; set; }
        Action<ComponentBag> Routine { get; }
        SystemType SystemType { get; }
        Type[] TargetedComponentTypes { get; }
    }
}
