using FluentAssertions;
using Xunit;

namespace Optsol.Components.Specification.Test
{
    public class SpecificationEmailSpec
    {
        [Trait("Specification", "ValueObject")]
        [Fact(DisplayName = "Deve validar email com o endereço informado")]
        public void DeveValidarEmailComEnderecoInformado()
        {
            //given
            var endereco = "weslley.carneiro@optsol.com.br";
            var email = new Email(endereco);

            //when
            var resultValidation = email.IsValid();

            //then
            resultValidation.Should().BeTrue();
        }

        [Trait("Specification", "ValueObject")]
        [Fact(DisplayName = "Deve retornar inválido se o endereço não for informado")]
        public void DeveRetornarInvalidoSeEndecoNaoForInformado()
        {
            //given
            var endereco = "";
            var email = new Email(endereco);

            //when
            var resultValidation = email.IsValid();

            //then
            resultValidation.Should().BeFalse();
        }

        [Trait("Specification", "ValueObject")]
        [Fact(DisplayName = "Deve retornar inválido se o endereço não for um e-mail")]
        public void DeveRetornarInvalidoSeEndecoNaoForUmEmail()
        {
            //given
            var endereco = "esteemalestainvalido.comm";
            var email = new Email(endereco);

            //when
            var resultValidation = email.IsValid();

            //then
            resultValidation.Should().BeFalse();
        }
    }
}
