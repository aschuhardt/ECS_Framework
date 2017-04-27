using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    class NameComponent : ECS_Framework.Component.ComponentBase
    {
        public string Name { get; set; }

        public NameComponent(Guid entID) : base(entID)
        {
            Name = "";
        }
    }
}
