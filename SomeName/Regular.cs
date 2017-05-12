using System.Text.RegularExpressions;

namespace SomeName
{
    public class RegularAttribute : SomeName
    {
        public override bool IsValid(object input)
        {
            return Regex.IsMatch(input.ToString(), Pattern.ToString());
        }
    }
}