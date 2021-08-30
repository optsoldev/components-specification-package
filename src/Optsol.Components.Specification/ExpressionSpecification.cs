using System;

namespace Optsol.Components.Specification
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Func<T, bool> expresion;

        public ExpressionSpecification(Func<T, bool> expresion)
        {
            this.expresion = expresion ?? throw new ArgumentNullException(nameof(expresion));
        }

        public override bool IsSatisfiedBy(T candidate) => expresion(candidate);
    }
}
