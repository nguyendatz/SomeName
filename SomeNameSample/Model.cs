using SomeName;

namespace SomeNameSample
{
    public class Model
    {
        [Required(ErrorMessage = "Email is required!")]
        [Regular(Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Custom(Method = "EmailExists", ErrorMessage = "This email already exists.")]
        public string Email { get; set; }
    }
}