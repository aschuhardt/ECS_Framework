using System;

namespace ECS_Framework.Component
{
    public abstract class ComponentBase : IComponent
    {
        public Guid EntityID { get; set; }

        private ComponentBase()
        {

        }

        public ComponentBase(Guid entityID)
        {
            EntityID = entityID;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType()
                && ((IComponent)obj).EntityID == this.EntityID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode() | EntityID.GetHashCode();
        }
    }
}
