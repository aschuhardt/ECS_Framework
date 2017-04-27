using ECS_Framework.Component;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECS_Framework
{
    public class ComponentBag
    {
        private Dictionary<Type, List<IComponent>> _contents;

        public ComponentBag()
        {
            _contents = new Dictionary<Type, List<IComponent>>();
        }

        private ComponentBag(Dictionary<Type, List<IComponent>> source, params Type[] desired)
        {
            _contents = new Dictionary<Type, List<IComponent>>();
            foreach (Type t in desired)
            {
                if (source.ContainsKey(t))
                {
                    _contents.Add(t, source[t]);
                }
            }
        }

        public void AddComponent<T>(Guid entityID) where T : ComponentBase
        {
            Type compType = typeof(T);
            if (!_contents.ContainsKey(compType)) _contents.Add(compType, new List<IComponent>());
            T newComp = (T)Activator.CreateInstance(compType, entityID);
            _contents[compType].Add(newComp);
        }

        public void AddComponent(Type type, Guid entityID)
        {
            if (!_contents.ContainsKey(type)) _contents.Add(type, new List<IComponent>());
            _contents[type].Add((IComponent)Activator.CreateInstance(type, entityID));
        }

        public void AddComponents(Guid entityID, params Type[] types)
        {
            foreach (Type t in types)
            {
                AddComponent(t, entityID);
            }
        }

        public IEnumerable<IComponent> GetComponents<T>() where T : IComponent
        {
            Type comp = typeof(T);
            if (_contents.ContainsKey(comp))
            {
                return _contents[comp];
            }
            else
            {
                return new List<IComponent>();
            }
        }

        public ComponentBag GetSubset(params Type[] types)
        {
            return new ComponentBag(_contents, types);
        }

        public IEnumerable<EntityContainer> GetEntitiesWithComponents(params Type[] components)
        {
            List<EntityContainer> ret = new List<EntityContainer>();

            foreach (var x in _contents
                .Where(x => components.Contains(x.Key))    //for each of our components in the specified type range
                .SelectMany(x => x.Value)                       //get all of them
                .GroupBy(x => x.EntityID))                       //group them by their EntityID
            {
                //HashSet<Type> diff = new HashSet<Type>(components);
                //diff.SymmetricExceptWith(x.Select(y => y.GetType()));   //check whether there are any differences between this entity's collection of 
                //if (!diff.Any())                                        //types and that which was requested
                //{
                ret.Add(new EntityContainer(x.Key, x.Select(z => z).ToList())); //if there are none, then create a new entity container and add to output
                //}
            }

            return ret;
        }

        public EntityContainer GetEntityByID(Guid id)
        {
            IEnumerable<IComponent> comps = _contents.SelectMany(x => x.Value).Where(x => x.EntityID == id);
            return new EntityContainer(id, comps.ToList());
        }
    }
}
