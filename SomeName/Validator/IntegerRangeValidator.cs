using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class IntegerRangeValidator : RangeValidator<int>
    {
        private string errorMessage = "integer range invalid";

        public IntegerRangeValidator(int min, int max) : base(min, max)
        {
        }

        public IntegerRangeValidator(int min, int max, IValidator<int> validator) : base(min, max, validator)
        {
        }

        protected override bool Compare(int input)
        {
            return Min <= input && input < Max;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
