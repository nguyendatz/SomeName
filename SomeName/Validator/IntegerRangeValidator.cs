using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    class IntegerRangeValidator : RangeValidator<int>
    {
        public IntegerRangeValidator(int min, int max) : base(min, max)
        {

        }

        protected override bool Compare(object input)
        {
            return Min <= (int)input && (int)input < Max;
        }
    }
}
