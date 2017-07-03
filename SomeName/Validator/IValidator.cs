using SomeName.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public interface IValidator<TValue>
    {
        bool IsValid(TValue input, Context context, string propName);
        bool IsValid(TValue input);
    }
}
