using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public interface IValidator<TValue>
    {
        TValue Value { get; set; }
        bool Validate();
    }
}
