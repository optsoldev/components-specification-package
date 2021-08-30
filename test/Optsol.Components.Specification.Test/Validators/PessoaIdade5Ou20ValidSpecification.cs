using System.Linq;

namespace Optsol.Components.Specification.Test.Validators
{
    public class PessoaIdade5Ou20ValidSpecification : CompositeSpecification<Pessoa>
    {
        private static readonly int[] IdadesPermitidas = { 5, 20 };

        public override bool IsSatisfiedBy(Pessoa candidate)
        {
            var idadeForaDosPadroes = !IdadesPermitidas.Any(idade => candidate.Idade == idade);
            if (idadeForaDosPadroes)
            {
                return false;
            }

            return true;
        }
    }
}
