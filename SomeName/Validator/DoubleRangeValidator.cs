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

        public override int Compare(double a, double b)
        {
            if (a < b) return -1;
            else if (a > b) return 1;
            else return 0;
        }
    }
}
