using System;

namespace Optsol.Components.Specification.Test.Abstract
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public abstract bool IsValid();
    }
}
