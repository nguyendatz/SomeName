using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Processor;

namespace SomeName.Validator
{
    public class MinLengthValidator : ValidatorDecorator<string>
    {
        private string errorMessage = "min length invalid";
        private int length;

        public MinLengthValidator(int length)
        {
            this.length = length;
        }

        public MinLengthValidator(int length, IValidator<string> validator) : base(validator)
        {
            this.length = length;
        }

        public override bool IsValid(string input, Context context, string propName)
        {
            bool valid = Check(input);

            if (!valid)
            {
                context.AddError(errorMessage, propName);
            }

            if (validator != null)
            {
                return valid && validator.IsValid(input, context, propName);
            }

            return valid;
        }

        public override bool IsValid(string input)
        {
            bool valid = Check(input);
        
            if (validator != null)
            {
                return valid && validator.IsValid(input);
            }

            return valid;
        }

        private bool Check(string input)
        {
            return input.Length >= length;
        }
    }
}
