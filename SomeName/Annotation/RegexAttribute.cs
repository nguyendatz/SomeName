using System;
using System.Text.RegularExpressions;

namespace SomeName.Annotation
{
    public class RegexAttribute : SomeNameAttribute
    {
        public string Pattern { get; set; }
    }
}