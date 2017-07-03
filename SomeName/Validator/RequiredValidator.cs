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

        public RequiredValidator() { }

        public RequiredValidator(IValidator<TValue> validator) : base(validator)
        {
        }

        public override bool IsValid(TValue input, Context context, string propName)
        {
            bool valid = Check(input);

            if (!valid)
            {
                context.AddError(propName, errorMessage);
            }

            if (validator != null)
            {
                return valid && validator.IsValid(input, context, propName);
            }
            return valid;
        }

        public override bool IsValid(TValue input)
        {
            bool valid = Check(input);
            if (validator != null)
            {
                return valid && validator.IsValid(input);
            }
            return valid;
        }

        private bool Check(TValue input)
        {
            if (input.GetType().Equals(typeof(string)))
            {
                string strInput = (string)Convert.ChangeType(input, typeof(string));
                return strInput != null && strInput.Length != 0;
            }

            return input != null;
        }
    }
}
