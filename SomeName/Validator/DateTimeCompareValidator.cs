using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class DateTimeCompareValidator : CompareValidator<DateTime>
    {
        private string errorMessage = "Datetime compare error";

        public DateTimeCompareValidator(DateTime other, Comparison CType): base(other, CType)
        {
        }

        public DateTimeCompareValidator(DateTime other, Comparison CType, IValidator<DateTime> validator) : base(other, CType, validator)
        {
        }

        protected override bool Equal(DateTime input)
        {
            return input == Other;
        }

        protected override bool GreaterThan(DateTime input)
        {
            return input > Other;
        }

        protected override bool GreaterThanEqual(DateTime input)
        {
            return input >= Other;
        }

        protected override bool LessThan(DateTime input)
        {
            return input < Other;
        }

        protected override bool LessThanEqual(DateTime input)
        {
            return input <= Other;
        }

        protected override bool NotEqual(DateTime input)
        {
            return input != Other;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
