namespace Optsol.Components.Specification.Test.Validators
{
    public class MaiorIdadeValidSpecification : CompositeSpecification<Pessoa>
    {
        private const int maiorIdade = 18;
        
        public override bool IsSatisfiedBy(Pessoa candidate)
        {
            if (candidate.Idade < maiorIdade)
                return false;

            return true;
        }
    }
}
