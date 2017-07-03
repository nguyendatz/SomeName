using System;

namespace SomeName.Annotation
{
    public abstract class SomeNameAttribute: Attribute
    {
        public string Message { get; set; }
    }
}