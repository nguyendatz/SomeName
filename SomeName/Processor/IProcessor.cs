using SomeName.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Processor
{
     public interface IProcessor
    {
        ValidationResult Result();

        IProcessor DoValidate();
       
        IProcessor On<TValue>(TValue value, IValidator<TValue> validator);
    }
}
