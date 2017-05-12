using SomeName;

namespace SomeNameSample
{
    public class Model
    {
        [Required(ErrorMessage = "Email is required!")]
        [Regular(Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
    }
}