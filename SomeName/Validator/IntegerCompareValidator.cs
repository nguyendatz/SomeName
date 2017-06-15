﻿using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class IntegerCompareValidator : CompareValidator<int>
    {
        public IntegerCompareValidator(object input, Comparison CType): base((int)input, CType)
        {
        }

        protected override bool Equal(object other)
        {
            return Input == (int)other;
        }

        protected override bool GreaterThan(object other)
        {
            return Input > (int)other;
        }

        protected override bool GreaterThanEqual(object other)
        {
            return Input >= (int)other;
        }

        protected override bool LessThan(object other)
        {
            return Input < (int)other;
        }

        protected override bool LessThanEqual(object other)
        {
            return Input <= (int)other;
        }

        protected override bool NotEqual(object other)
        {
            return Input != (int)other;
        }
    }
}