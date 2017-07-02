using System.Text.RegularExpressions;

namespace SomeName.Annotation
{
    public class RegularAttribute : SomeNameAttribute
    {
        public string Pattern { get; set; }

        public override bool IsValid(object[] input)
        {
            return Regex.IsMatch(input[0].ToString(), Pattern.ToString());
        }
    }
}