using FluentAssertions;
using Optsol.Components.Specification.Test.Validators;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Optsol.Components.Specification.Test
{
    public class SpecificationSpec
    {
        public static List<Pessoa> ObterPessoas => new()
        {
            new Pessoa("Weslley 1", 5, new Email("weslley.1@optsol.com.br")),
            new Pessoa("Weslley 2", 10, new Email("weslley.2@optsol.com.br")),
            new Pessoa("Weslley 3", 20, new Email("weslley.3@optsol.com.br")),
            new Pessoa("Weslley 4", 60, new Email("weslley.4@optsol.com.br")),
            new Pessoa("Weslley 5", 70, new Email("weslley.5@optsol.com.br"))
        };

        [Trait("Specification", "Custom")]
        [Fact(DisplayName = "Deve retornar pessoas com idade maior que 10 e menor que 70")]
        public void DeveRetornarPessoasComIdadeMaior10Menor70()
        {
            //given 
            var idadeMinima = 10;
            var idadeMaxima = 70;

            ISpecification<Pessoa> partnerSpecification = new ExpressionSpecification<Pessoa>(pessoa => pessoa.Idade > idadeMinima && pessoa.Idade < idadeMaxima);

            //when
            var pessoas = ObterPessoas.FindAll(pessoa => partnerSpecification.IsSatisfiedBy(pessoa));

            //then
            pessoas.Should().NotBeEmpty();
            pessoas.Should().HaveCount(2);
            pessoas.All(a => a.Idade > idadeMinima && a.Idade < idadeMaxima).Should().BeTrue();
        }

        [Trait("Specification", "Custom")]
        [Fact(DisplayName = "Deve retornar pessoas com idade 5 e 20 anos")]
        public void DeveRetornarPessoasComIdade5Ou20()
        {
            //given
            ISpecification<Pessoa> partnerSpecification = new PessoaIdade5Ou20ValidSpecification();

            //when
            var pessoas = ObterPessoas.FindAll(pessoa => partnerSpecification.IsSatisfiedBy(pessoa));

            //then
            pessoas.Should().NotBeEmpty();
            pessoas.Should().HaveCount(2);
            pessoas.All(a => a.Idade == 5 || a.Idade == 20).Should().BeTrue();
        }

        [Trait("Specification", "Custom")]
        [Fact(DisplayName = "Deve retornar pessoas validas que não tenha idade 5 e 20 anos")]
        public void DeveRetornarPessoasQueNaoTenhaIdade5Ou20()
        {
            //given
            var naoContemIdades = new int[] { 5, 20 };

            ISpecification<Pessoa> pessoaValida = new PessoaValidSpecification();
            ISpecification<Pessoa> pessoaIdade5Ou20 = new PessoaIdade5Ou20ValidSpecification();

            var partnerSpecification = pessoaValida.AndNot(pessoaIdade5Ou20);

            //when
            var pessoas = ObterPessoas.FindAll(pessoa => partnerSpecification.IsSatisfiedBy(pessoa));

            //then
            pessoas.Should().NotBeEmpty();
            pessoas.Should().HaveCount(3);
            pessoas.All(a => !naoContemIdades.Contains(a.Idade)).Should().BeTrue();
        }

        [Trait("Specification", "Custom")]
        [Fact(DisplayName = "Deve retornar pessoas com idade 5, 20 ou 70 anos")]
        public void DeveRetornarPessoasComIdade5Ou20Ou70Anos()
        {
            //given
            var idade = 70;
            var naoContemIdades = new int[] { 5, 20, idade };

            ISpecification<Pessoa> pessoaIdade5Ou20 = new PessoaIdade5Ou20ValidSpecification();
            ISpecification<Pessoa> pessoaIdade70 = new ExpressionSpecification<Pessoa>(pessoa => pessoa.Idade == idade);

            var partnerSpecification = pessoaIdade5Ou20.Or(pessoaIdade70);

            //when
            var pessoas = ObterPessoas.FindAll(pessoa => partnerSpecification.IsSatisfiedBy(pessoa));

            //then
            pessoas.Should().NotBeEmpty();
            pessoas.Should().HaveCount(3);
            pessoas.All(a => naoContemIdades.Contains(a.Idade)).Should().BeTrue();
        }

        [Trait("Specification", "Custom")]
        [Fact(DisplayName = "Deve retornar pessoas com idade 5 ou 20 ou não chama Marcelo")]
        public void DeveRetornarPessoasComIdade5Ou20ENaoChamaMarcelo()
        {
            //given
            string nome = "Marcelo";

            ISpecification<Pessoa> pessoaIdade5Ou20 = new PessoaIdade5Ou20ValidSpecification();
            ISpecification<Pessoa> pessoaNome = new ExpressionSpecification<Pessoa>(pessoa => pessoa.Nome.ToLower().Contains(nome));

            var partnerSpecification = pessoaIdade5Ou20.OrNot(pessoaNome);

            //when
            var pessoas = ObterPessoas.FindAll(pessoa => partnerSpecification.IsSatisfiedBy(pessoa));

            //then
            pessoas.Should().NotBeEmpty();
            pessoas.Should().HaveCount(5);
            pessoas.All(a => !a.Nome.ToLower().Contains(nome)).Should().BeTrue();
        }

        [Trait("Specification", "Custom")]
        [Fact(DisplayName = "Deve retornar pessoas válidas que não chamem Weslley")]
        public void DeveRetornarPessoasValidasQueNaoChamemWeslley()
        {
            //given
            string nome = "Weslley";

            ISpecification<Pessoa> pessoaValida = new PessoaValidSpecification();
            ISpecification<Pessoa> pessoaNome = new ExpressionSpecification<Pessoa>(pessoa => pessoa.Nome.ToLower().Contains(nome));

            var partnerSpecification = pessoaValida.Not(pessoaNome);

            //when
            var pessoas = ObterPessoas.FindAll(pessoa => partnerSpecification.IsSatisfiedBy(pessoa));

            //then
            pessoas.Should().BeEmpty();
        }
    }
}
