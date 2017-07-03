using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class DoubleCompareValidator : CompareValidator<double>
    {
        private string errorMessage = "Double compare failed.";

        public DoubleCompareValidator(double other, Comparison CType): base(other, CType)
        {
        }

        public DoubleCompareValidator(double other, Comparison CType, IValidator<double> validator) : base(other, CType, validator)
        {
        }

        protected override bool Equal(double input)
        {
            return input == Other;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }

        protected override bool GreaterThan(double input)
        {
            return input > Other;
        }

        protected override bool GreaterThanEqual(double input)
        {
            return input >= Other;
        }

        protected override bool LessThan(double input)
        {
            return input < Other;
        }

        protected override bool LessThanEqual(double input)
        {
            return input <= Other;
        }

        protected override bool NotEqual(double input)
        {
            return input != Other;
        }

        
    }
}
