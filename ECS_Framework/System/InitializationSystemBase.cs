using System;
using System.Collections.Generic;
using ECS_Framework.Component;

namespace ECS_Framework.System
{
    public abstract class InitializationSystemBase : ISystem
    {
        public ECSManager Manager { get; set; }
        public Action<ComponentBag> Routine => ExecutionRoutine();
        public SystemType SystemType => SystemType.Initialization;
        public Type[] TargetedComponentTypes => new Type[] { };
        protected abstract Action<ComponentBag> ExecutionRoutine();
    }
}
