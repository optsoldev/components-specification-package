using Optsol.Components.Specification.Test.Abstract;
using Optsol.Components.Specification.Test.Validators;

namespace Optsol.Components.Specification.Test
{
    public class Email : ValueObject
    {
        protected CompositeSpecification<Email> ValidSpecification;

        public Email(string endereco)
        {
            Endereco = endereco;

            ValidSpecification = new EmailValidSpecification();
        }

        public string Endereco { get; private set; }

        public override bool IsValid()
        {
            return ValidSpecification.IsSatisfiedBy(this);
        }
    }
}
