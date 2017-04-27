using ECS_Framework.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_Framework;

namespace ExampleApp
{
    class PersonInitSystem : CreationSystemBase
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
            return (data) =>
            {
                EntityContainer ent = data.GetEntityByID(NewEntityID);
                ent.GetComponent<AgeComponent>().Age = 1;
                ent.GetComponent<NameComponent>().Name = $"William-{Math.Abs(ent.ID.GetHashCode()) % 10}";
                //Console.WriteLine($"Initializing the age of {ent.GetComponent<NameComponent>().Name} to 1.");
            };
        }
    }
}
