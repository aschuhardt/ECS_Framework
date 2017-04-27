using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_Framework;
using ECS_Framework.System;

namespace ExampleApp
{
    class AgeIncrementSystem : IterationSystemBase
    {
        protected override Type[] ComponentTypes()
        {
            return new Type[]
            {
                typeof(AgeComponent),
                typeof(NameComponent)
            };
        }

        protected override Action<ComponentBag> ExecutionRoutine()
        {
            return (data) => {
                IEnumerable<EntityContainer> ents = data.GetEntitiesWithComponents(ComponentTypes());
                ents.ToList().ForEach(x =>
                {
                    x.GetComponent<AgeComponent>().Age++;
                    //Console.WriteLine($"Setting the age of {x.GetComponent<NameComponent>().Name} to {x.GetComponent<AgeComponent>().Age}.");
                });
            };
        }
    }
}
