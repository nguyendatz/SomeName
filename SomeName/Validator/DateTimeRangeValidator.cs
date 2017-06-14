using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    class DateTimeRangeValidator : RangeValidator<DateTime>
    {
        public DateTimeRangeValidator(DateTime min, DateTime max) : base(min, max)
        {

        }

        protected override bool Compare(object input)
        {
            return Min <= (DateTime)input && (DateTime)input < Max;
        }
    }
}
