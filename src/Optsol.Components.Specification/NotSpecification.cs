﻿namespace Optsol.Components.Specification
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> wrapped;

        public NotSpecification(ISpecification<T> not)
        {
            this.wrapped = not;
        }

        public override bool IsSatisfiedBy(T candidate) 
            => !wrapped.IsSatisfiedBy(candidate);
    }
}