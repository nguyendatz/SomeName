using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class StringCompareValidator : CompareValidator<string>
    {
        private string errorMessage = "String compare invalid.";

        public StringCompareValidator(string other, Comparison CType): base(other, CType)
        {
        }

        public StringCompareValidator(string other, Comparison CType, IValidator<string> validator) : base(other, CType, validator)
        {
        }

        protected override bool Equal(string input)
        {
            return input == Other;
        }

        protected override string GetErrorMessage()
        {
            return errorMessage;
        }

        protected override bool GreaterThan(string input)
        {
            return false;
        }

        protected override bool GreaterThanEqual(string input)
        {
            return false;
        }

        protected override bool LessThan(string input)
        {
            return false;
        }

        protected override bool LessThanEqual(string input)
        {
            return false;
        }

        protected override bool NotEqual(string input)
        {
            return input != Other;
        }
    }
}
