using System;

namespace Optsol.Components.Specification.Test.Validators
{
    public class PessoaValidSpecification : CompositeSpecification<Pessoa>
    {
        public override bool IsSatisfiedBy(Pessoa candidate)
        {
            if (string.IsNullOrEmpty(candidate.Nome))
                return false;
                                    
            return true;
        }
    }
}
