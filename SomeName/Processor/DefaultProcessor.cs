using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Validator;

namespace SomeName.Processor
{
    public class DefaultProcessor : IProcessor
    {
        private Context context = new Context();

        public IProcessor DoValidate()
        {
            return this;
        }

        public IProcessor On<TValue>(TValue value, IValidator<TValue> validator)
        {
            validator.IsValid(value, context);
            return this;
        }

        public ValidationResult Result()
        {
            throw new NotImplementedException();
        }
    }
}
