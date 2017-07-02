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
        private List<Tuple<T, IValidator, string>> validatorList = new List<Tuple<T, IValidator, string>>();
        private ValidationResult result = new ValidationResult();
        private int propsCount;

        public NormalProcessor()
        {
            propsCount = 0;
        }

        public ValidationResult Result()
        {
            return result;
        }

        public IProcessor<T> DoValidate()
        {
            foreach (Tuple<T, IValidator, string> tuple in validatorList)
            {
                T value = tuple.Item1;
                IValidator validator = tuple.Item2;

                if (!validator.IsValid(value))
                {
                    string propertyName = tuple.Item3;
                    result.AddError(propertyName, validator.DefaultMessage);
                }
            }
            return this;
        }

        public IProcessor<T> On(T value, IValidator validator, string propertyName)
        {
            validatorList.Add(new Tuple<T, IValidator, string>(value, validator, getPropertyName(propertyName)));
            return this;
        }

        private string getPropertyName(string propertyName)
        {
            return propertyName == "prop" ? propertyName + propsCount++ : propertyName;
        }
    }
}
