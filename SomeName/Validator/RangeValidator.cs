using SomeName.Processor;
using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class RangeValidator<TValue> : ValidatorDecorator<TValue>
    {
        protected TValue Min { get; set; }
        protected TValue Max { get; set; }

        public RangeValidator(TValue min, TValue max)
        {
            Min = min;
            Max = max;
        }

        public RangeValidator(TValue min, TValue max, IValidator<TValue> validator) : base(validator)
        {
            Min = min;
            Max = max;
        }

        public override bool IsValid(TValue input)
        {
            if (validator != null)
            {
                return Compare(input) && validator.IsValid(input);
            }
            return Compare(input);
        }

        public override bool IsValid(TValue input, Context context, string propName)
        {
            if (!Compare(input))
            {
                context.AddError(propName, GetErrorMessage());
            }

            if (validator != null)
            {
                return Compare(input) && validator.IsValid(input, context, propName);
            }

            return Compare(input);
        }

        protected abstract bool Compare(TValue input);
        protected abstract string GetErrorMessage();
    }
}
