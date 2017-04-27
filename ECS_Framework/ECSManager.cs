using System;
using System.Collections.Generic;
using System.Linq;
using ECS_Framework.Component;
using ECS_Framework.Entity;
using ECS_Framework.System;

namespace ECS_Framework
{
    public class ECSManager
    {
        private ComponentBag _components;
        private List<ISystem> _systems;
        private bool _initialized;

        public ECSManager()
        {
            InitializeState();
        }

        /// <summary>
        /// Adds a new instance of the given entity type to the internal collection of entities.
        /// Also adds each of that entity type's components to the internal collection of components.
        /// </summary>
        /// <typeparam name="T">The type of the new entity to be created.</typeparam>
        public void AddEntity<T>() where T: IEntity
        {
            IEntity newEnt = (T)Activator.CreateInstance<T>();
            _components.AddComponents(newEnt.ID, newEnt.ComponentsTypes);
            foreach (CreationSystemBase sys in _systems.OfType<CreationSystemBase>()
                .Where(x => x.TargetedComponentTypes.All(y => newEnt.ComponentsTypes.Contains(y))))
            {
                sys.NewEntityID = newEnt.ID;
                sys.Routine(_components.GetSubset(sys.TargetedComponentTypes));
            }
        }

        /// <summary>
        /// Adds a new instance of the specified system type to the internal collection of systems.
        /// </summary>
        public void AddSystem<T>() where T: ISystem
        {
            ISystem sysInstance = Activator.CreateInstance<T>();
            sysInstance.Manager = this;
            _systems.Add(sysInstance);
        }

        /// <summary>
        /// On the first time this is called, init systems are run.
        /// On each subsequent time this is called, iteration systems are run.
        /// </summary>
        public void Update()
        {
            if (!_initialized)
            {
                RunSystemsOfType(SystemType.Initialization);
                _initialized = true;
            }
            else
            {
                RunSystemsOfType(SystemType.Iteration);
            }
        }
                
        /// <summary>
        /// Resets the manager to its original state
        /// </summary>
        public void Reset()
        {
            InitializeState();
        }

        private void InitializeState()
        {
            _components = new ComponentBag();
            _systems = new List<ISystem>();
            _initialized = false;
        }

        private void RunSystemsOfType(SystemType st)
        {
            RunSystemsOfType(st, Guid.Empty);
        }

        private void RunSystemsOfType(SystemType st, Guid entID)
        {
            foreach (ISystem sys in _systems.Where(x => x.SystemType == st))
            {
                if (st == SystemType.Creation)
                {
                    ((CreationSystemBase)sys).NewEntityID = entID;
                }
                sys.Routine(_components.GetSubset(sys.TargetedComponentTypes));
            }
        }
    }
}
