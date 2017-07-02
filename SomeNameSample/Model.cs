using SomeName;
using SomeName.Util;
using SomeName.Annotation;

namespace SomeNameSample
{
    public class Model
    {
<<<<<<< HEAD
        [Required(ErrorMessage ="Full name is required!")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Username is required!")]
        [Regular(Pattern = @"^[a-z0-9_-]{3,15}$", ErrorMessage = "Username: 3 to 15 characters with any lower case character, digit or special symbol “_-” only")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [Regular(Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Custom(Method = "EmailExists", Class = "SomeNameSample.Main", Library ="SomeNameSample", ErrorMessage = "This email already exists.", Params = new[] { "abc@def.com" })]
=======
>>>>>>> hi
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(Length = 6, ErrorMessage ="Password's length must more than 6")]
        [MaxLength(Length = 50, ErrorMessage = "Password's length must less than 50")]
        public string Password { get; set; }

        [Compare(CompareTo = "Password", ComparisonType = Comparison.Equal, Type = DataType.String, ErrorMessage = "Confirm Password must same to Password")]
        public string ConfirmPassword { get; set; }
    }
}