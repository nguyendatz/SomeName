using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    class DateTimeRangeValidator : RangeValidator
    {
        public DateTimeRangeValidator(object input, object min, object max) : base(input, min, max)
        {
        }

        protected override bool SoSanh()
        {
            return (DateTime)_min <= (DateTime)_input && (DateTime)_input < (DateTime)_max;
        }
    }
}
