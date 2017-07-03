using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Processor;

namespace SomeName.Validator
{
    public abstract class ValidatorDecorator<TValue> : IValidator<TValue>
    {
        protected IValidator<TValue> validator;

        public ValidatorDecorator() { }

        public ValidatorDecorator(IValidator<TValue> validator)
        {
            this.validator = validator;
        }

        public abstract bool IsValid(TValue input, Context context, string propName);

        public abstract bool IsValid(TValue input);
    }
}
