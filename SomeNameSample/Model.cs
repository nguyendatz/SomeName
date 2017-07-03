using SomeName;

namespace SomeNameSample
{
    public class Model
    {
        [Required(ErrorMessage ="Full name is required!")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Username is required!")]
        [Regular(Pattern = @"^[a-z0-9_-]{3,15}$", ErrorMessage = "Username: 3 to 15 characters with any lower case character, digit or special symbol “_-” only")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [Regular(Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Custom(Method = "EmailExists", Class = "SomeNameSample.Main", Library ="SomeNameSample", ErrorMessage = "This email already exists.", Params = new[] { "abc@def.com" })]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        [Compare(CompareTo = "Password", ComparisonType = Comparison.Equal, Type = DataType.String, ErrorMessage = "Confirm Password must same to Password")]
        public string ConfirmPassword { get; set; }

        public string ID;
    }
}