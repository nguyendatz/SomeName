using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    class StringCompareValidator : CompareValidator<string>
    {
        public StringCompareValidator(object input, Comparison CType): base((string)input, CType)
        {
        }

        protected override bool Equal(object other)
        {
            return Input == (string)other;
        }

        protected override bool GreaterThan(object other)
        {
            return false;
        }

        protected override bool GreaterThanEqual(object other)
        {
            return false;
        }

        protected override bool LessThan(object other)
        {
            return false;
        }

        protected override bool LessThanEqual(object other)
        {
            return false;
        }

        protected override bool NotEqual(object other)
        {
            return Input != (string)other;
        }
    }
}
