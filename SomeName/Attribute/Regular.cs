using System.Text.RegularExpressions;

namespace SomeName.Attribute
{
    public class RegularAttribute : SomeName
    {
        public string Pattern { get; set; }

        public override bool IsValid(object[] input)
        {
            return Regex.IsMatch(input[0].ToString(), Pattern.ToString());
        }
    }
}