using SomeName;

namespace SomeNameSample
{
    public class Model
    {
        [Required(ErrorMessage = "Email is required!")]
        [Regular(Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Custom(Method = "EmailExists", ErrorMessage = "This email already exists.", Params = new[] { "abc@def.com" })]
        public string Email { get; set; }

        [Compare(CompareTo = "Email", ComparisonType = Comparison.Equal, Type = DataType.String)]
        public string RepeatEmail { get; set; }
    }
}