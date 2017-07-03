using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class StringLengthAttribute : SomeName
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public override void IsValid(object[] input)
        {
            Validation v = new IntegerRangeValidation(input[0].ToString().Length, Min, Max + 1);
            ValidationGroupManager.GetInstance().AddValidationToGroup(v, GroupName);
        }
    }
}
