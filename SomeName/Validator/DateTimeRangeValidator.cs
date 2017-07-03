using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class DateTimeRangeValidator : RangeValidator<DateTime>
    {
        private string errorMessage = "datetime range error ";

        public DateTimeRangeValidator(DateTime min, DateTime max) : base(min, max)
        {

        }

        public DateTimeRangeValidator(DateTime min, DateTime max, IValidator<DateTime> validator) : base(min, max, validator)
        {

        }

        protected override bool Compare(DateTime input)
        {
            return Min <= input && input < Max;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
