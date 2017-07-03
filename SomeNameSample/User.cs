using SomeName;
using SomeName.Util;
using SomeName.Annotation;

namespace SomeNameSample
{
    public class User
    {
        [Required(Message = "Username is required!")]
        public string Username { get; set; }
    }
}