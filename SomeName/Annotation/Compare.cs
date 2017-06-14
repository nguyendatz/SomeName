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
        public DataType Type { get; set; }

        public override bool IsValid(object[] Input)
        {
            Validation cv = CompareValidator.Create(Input[0], Input[1], ComparisonType, Type);
            return cv.isValid();
        }
    }
}
