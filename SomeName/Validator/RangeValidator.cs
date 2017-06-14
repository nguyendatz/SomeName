using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class RangeValidator<TValue> : IValidator<TValue>
    {
        public TValue Value { get; set; }

        public TValue Min { get; set; }
        public TValue Max { get; set; }

        public RangeValidator(TValue min, TValue max)
        {
            Min = min;
            Max = max;
        }

        public bool Validate()
        {
            if (Compare(Value, Min) >= 0 && Compare(Value, Max) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract int Compare(TValue a, TValue b);
    }
}
