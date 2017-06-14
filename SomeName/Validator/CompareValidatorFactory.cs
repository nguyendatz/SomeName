using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public class CompareValidatorFactory
    {
        public static IValidator Create<T>(T input, Comparison CType, DataType DType)
        {
            return new StringCompareValidator(input, CType);
            //throw new NotImplementedException();
        }
    }
}
