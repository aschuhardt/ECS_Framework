using ECS_Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    class PersonEntity : EntityBase
    {
        protected override Type[] Components()
        {
            return new Type[]
            {
                typeof(AgeComponent),
                typeof(NameComponent)
            };
        }
    }
}
