using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class DoubleRangeValidator : RangeValidator<double>
    {
        private string errorMessage = "double range invalid";

        public DoubleRangeValidator(double min, double max) : base(min, max)
        {
        }

        public DoubleRangeValidator(double min, double max, IValidator<double> validator) : base(min, max, validator)
        {
        }

        protected override bool Compare(double input)
        {
            return Min <= input && input < Max;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
