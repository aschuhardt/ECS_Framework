using System;
using System.Collections.Generic;
using ECS_Framework.Component;

namespace ECS_Framework.System
{
    public abstract class IterationSystemBase : ISystem
    {
        public ECSManager Manager { get; set; }
        public Action<ComponentBag> Routine => ExecutionRoutine();
        public SystemType SystemType => SystemType.Iteration;
        public Type[] TargetedComponentTypes => ComponentTypes();
        protected abstract Action<ComponentBag> ExecutionRoutine();
        protected abstract Type[] ComponentTypes();
    }
}
