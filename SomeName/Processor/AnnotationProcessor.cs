using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Processor;
using System.Reflection;
using SomeName.Annotation;
using SomeName.Validator;

namespace SomeName.Processor
{
    public class AnnotationProcessor : IProcessor
    {
        public IProcessor DoValidate()
        {
        }

        public IProcessor On<TValue>(TValue value, IValidator<TValue> validator)
        {
            var properties = value.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var atts = prop.GetCustomAttributes(typeof(SomeNameAttribute), true);

                foreach (SomeNameAttribute att in atts)
                {
                    if (att.GetType().Equals(typeof(RequiredAttribute)))
                    {
                    }
                }
            }
        }

        public ValidationResult Result()
        {
            throw new NotImplementedException();
        }
    }
}
