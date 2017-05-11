using System.Text.RegularExpressions;

namespace SomeName
{
    public class RegularAttribute : SomeName
    {
        public RegularAttribute(string pattern, string errorMessage = null)
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object input)
        {
            return Regex.IsMatch(input.ToString(), Pattern.ToString());
        }
    }
}