using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Attribute
{
    public class CompareAttribute : SomeName
    {
        public string CompareTo { get; set; }
        public Comparison ComparisonType { get; set; }
        public DataType Type { get; set; }

        public override bool IsValid(object[] Input)
        {
            Validation cv = CompareValidation.Create(Input[0], Input[1], ComparisonType, Type);
            return cv.isValid();
        }
    }
}
