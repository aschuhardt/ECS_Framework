using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_Framework;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ECSManager ecsm = new ECSManager();

            //add systems
            ecsm.AddSystem<PersonInitSystem>();
            ecsm.AddSystem<AgeIncrementSystem>();
            ecsm.AddSystem<StateInitializationSystem>();

            while (true)
                ecsm.Update();
        }
    }
}
