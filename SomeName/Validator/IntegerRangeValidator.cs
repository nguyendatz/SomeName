using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    class IntegerRangeValidator: RangeValidator
    {
        public IntegerRangeValidator(object input, object min, object max) : base(input, min, max)
        {
        }

        protected override bool SoSanh()
        {
            return (int)_min <= (int)_input && (int)_input < (int)_max;
        }
    }
}
