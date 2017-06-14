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
    public class NormalProcessor : IProcessor
    {
        private List<IValidator<object>> validatorList = new List<IValidator<object>>();
        private ValidationResult result = new ValidationResult();

        public ValidationResult Result()
        {
            return result;
        }

        public IProcessor DoValidate()
        {
            bool isValid = true;
            foreach (IValidator<object> validator in validatorList)
            {
                isValid = isValid && validator.Validate();
            }
            result.IsValid = isValid;
            result.AddError("gg", "wp");
            return this;
        }


        public IProcessor On<T>(T value, IValidator<T> validator)
        {
            validator.Value = value;
            validatorList.Add(validator);
            return this;
        }
    }
}
