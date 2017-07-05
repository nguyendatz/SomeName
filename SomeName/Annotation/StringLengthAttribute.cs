using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Annotation
{
    public class StringLengthAttribute : SomeNameAttribute
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
    }
}
