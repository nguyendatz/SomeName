using System;

namespace SomeName.Annotation
{
    public abstract class SomeNameAttribute: Attribute
    {
        public abstract bool IsValid(object[] input);

        public string ErrorMessage { get; set; }
    }
}