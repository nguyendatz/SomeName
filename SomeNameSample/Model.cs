using System;
using SomeName;

namespace SomeNameSample
{
    public class Model
    {
        [Regular(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
    }
}