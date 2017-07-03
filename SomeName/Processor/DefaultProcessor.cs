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

        public DefaultProcessor On<TValue>(TValue value, IValidator<TValue> validator, string propName = "prop")
        {
            validator.IsValid(value, context, propName);
            return this;
        }

        public Context Result()
        {
            return context;
        }
    }
}
