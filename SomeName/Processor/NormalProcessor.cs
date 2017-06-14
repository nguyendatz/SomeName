using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Validator;

namespace SomeName.Processor
{
    /// <summary>
    /// Process operator in added order
    /// </summary>
    public class NormalProcessor<T> : IProcessor<T>
    {
        private List<IValidator> validatorList = new List<IValidator>();
        private ValidationResult result = new ValidationResult();

        public ValidationResult Result()
        {
            return result;
        }

        IProcessor<T> IProcessor<T>.DoValidate()
        {
            /*bool isValid = true;
            foreach (IValidator<T> validator in validatorList)
            {
                isValid = isValid && validator.isValid(null);
            }

            result.IsValid = isValid;
            result.AddError("gg", "wp");*/

            return this;
        }

        public IProcessor<T> On(T value, IValidator validator)
        {
            validatorList.Add(validator);
            return this;
        }
    }
}
