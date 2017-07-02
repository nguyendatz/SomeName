using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    class DoubleRangeValidation : RangeValidation
    {
        public DoubleRangeValidation(object input, object min, object max) : base(input, min, max)
        {
        }

        protected override bool SoSanh()
        {
            return (double)_min <= (double)_input && (double)_input < (double)_max;
        }
    }
}
