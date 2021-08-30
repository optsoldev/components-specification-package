namespace Optsol.Components.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> rightCondition;
        private readonly ISpecification<T> leftCondition;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            leftCondition = left;
            rightCondition = right;
        }

        public override bool IsSatisfiedBy(T candidate) 
            => leftCondition.IsSatisfiedBy(candidate) && rightCondition.IsSatisfiedBy(candidate);
    }
}