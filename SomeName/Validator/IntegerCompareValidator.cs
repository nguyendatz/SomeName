using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class IntegerCompareValidator : CompareValidator<int>
    {
        private string errorMessage = "Integer compare invalid.";

        public IntegerCompareValidator(int other, Comparison CType): base(other, CType)
        {
        }

        public IntegerCompareValidator(int other, Comparison CType, IValidator<int> validator) : base(other, CType, validator)
        {
        }


        protected override bool Equal(int input)
        {
            return input == Other;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }

        protected override bool GreaterThan(int input)
        {
            return input > Other;
        }

        protected override bool GreaterThanEqual(int input)
        {
            return input >= Other;
        }

        protected override bool LessThan(int input)
        {
            return input < Other;
        }

        protected override bool LessThanEqual(int input)
        {
            return input <= Other;
        }

        protected override bool NotEqual(int input)
        {
            return input != Other;
        }
    }
}
