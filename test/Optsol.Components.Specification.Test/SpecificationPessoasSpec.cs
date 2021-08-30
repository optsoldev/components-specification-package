using FluentAssertions;
using Xunit;

namespace Optsol.Components.Specification.Test
{
    public class SpecificationPessoasSpec
    {
        [Trait("Specification", "Entity")]
        [Fact(DisplayName = "Deve validar pessoa maior idade e nome válido")]
        public void DeveValidarPessoaMaiorIdadeENomeValido()
        {
            //given
            var idade = 36;
            var pessoa = new Pessoa("Weslley Carneiro", idade, new Email("weslley.carneiro@optsol.com.br"));

            //when
            var resultValidation = pessoa.IsValid();

            //then
            resultValidation.Should().BeTrue();
        }

        [Trait("Specification", "Entity")]
        [Fact(DisplayName = "Deve retornar invalido se a pessoa for menor de idade")]
        public void DeveRetornarInvalidoSePessoaForMenorIdade()
        {
            //given
            var idade = 15;
            var pessoa = new Pessoa("Weslley Carneiro", idade, new Email("weslley.carneiro@optsol.com.br"));

            //when
            var resultValidation = pessoa.IsValid();

            //then
            resultValidation.Should().BeFalse();
        }
    }
}
