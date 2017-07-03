using System.Text.RegularExpressions;

namespace SomeName
{
    public class RegularAttribute : SomeName
    {
        public string Pattern { get; set; }

        public override void IsValid(object[] input)
        {
            //return Regex.IsMatch(input[0].ToString(), Pattern.ToString());
        }
    }
}