using System;

namespace SomeName
{
    public abstract class SomeName: Attribute
    {
        public abstract bool IsValid(object[] input);

        public string ErrorMessage { get; set; }
    }
}