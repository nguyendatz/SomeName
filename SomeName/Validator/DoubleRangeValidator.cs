using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class DoubleRangeValidator : RangeValidator<double>
    {
        public DoubleRangeValidator(double min, double max) : base(min, max)
        {
        }

        protected override bool Compare(object input)
        {
            return Min <= (double)input && (double)input < Max;
        }
    }
}
