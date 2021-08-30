using System.Text.RegularExpressions;

namespace Optsol.Components.Specification.Test.Validators
{
    public class EmailValidSpecification : CompositeSpecification<Email>
    {
        public override bool IsSatisfiedBy(Email candidate)
        {
            if (string.IsNullOrEmpty(candidate.Endereco))
                return false;

            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(candidate.Endereco ?? "", pattern);
        }
    }
}
