using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    class AgeComponent : ECS_Framework.Component.ComponentBase
    {
        public int Age { get; set; }

        public AgeComponent(Guid entID) : base(entID)
        {
            Age = 0;
        }
    }
}
