using System;

namespace SomeName
{
    public abstract class SomeName: Attribute
    {
        public string GroupName = "Default";
        public abstract void IsValid(object[] input);

        public string ErrorMessage { get; set; }
    }
}