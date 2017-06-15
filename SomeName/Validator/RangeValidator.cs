using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class RangeValidator<T> : IValidator
    {
        protected T Min { get; set; }
        protected T Max { get; set; }

        public RangeValidator(T min, T max)
        {
            Min = min;
            Max = max;
            DefaultMessage = "Value must be in range [" + min + ", " + max + ")";
        }

        override public bool IsValid<type>(type input)
        {
            return Compare(input);
        }

        protected abstract bool Compare(object input);
    }
}
