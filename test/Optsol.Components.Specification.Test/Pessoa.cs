using Optsol.Components.Specification.Test.Abstract;
using Optsol.Components.Specification.Test.Validators;

namespace Optsol.Components.Specification.Test
{
    public class Pessoa : Entity
    {
        protected ISpecification<Pessoa> ValidSpecification;

        public Pessoa(string nome, int idade, Email email)
        {
            Nome = nome;
            Idade = idade;
            Email = email;

            var pessoaValidation = new PessoaValidSpecification();
            var pessoMaiorIdade = pessoaValidation.And(new MaiorIdadeValidSpecification());

            ValidSpecification = pessoMaiorIdade;
        }

        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public Email Email { get; private set; }

        public override bool IsValid()
        {
            return ValidSpecification.IsSatisfiedBy(this);
        }
    }
}
