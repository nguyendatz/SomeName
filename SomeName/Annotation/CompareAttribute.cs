using SomeName.Util;
using SomeName.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Annotation
{
    public class CompareAttribute : SomeNameAttribute
    {
        public string CompareTo { get; set; }
        public Comparison ComparisonType { get; set; }
    }
}
