using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Processor;

namespace SomeName.Validator
{
    public class RequiredValidator<TValue> : ValidatorDecorator<TValue>
    {
        private string errorMessage = "This field is required.";

        public RequiredValidator(IValidator<TValue> validator) : base(validator)
        {
        }

        public override bool IsValid(TValue input, Context context)
        {
            context.AddErrorMessage(errorMessage);
            return IsValid(input) && validator.IsValid(input);
        }

        public override bool IsValid(TValue input)
        {
            return input != null;
        }
    }
}
