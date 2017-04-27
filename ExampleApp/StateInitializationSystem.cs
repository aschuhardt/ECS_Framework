using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_Framework;
using ECS_Framework.System;

namespace ExampleApp
{
    class StateInitializationSystem : InitializationSystemBase
    {
        protected override Action<ComponentBag> ExecutionRoutine()
        {
            return (data) =>
            {
                for (int i = 0; i < 1024; i++)
                {
                    Manager.AddEntity<PersonEntity>();
                }
            };
        }
    }
}
