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
        public static TValidator Create<TValidator, TValue>(TValue input, Comparison CType, DataType DType) where TValidator : CompareValidator<TValue>
        {
            switch (DType)
            {
                case DataType.Integer:
                    return (TValidator)Convert.ChangeType(new IntegerCompareValidator(Convert.ToInt32(input), CType), typeof(TValidator));
                case DataType.Double:
                    return (TValidator)Convert.ChangeType(new DoubleCompareValidator(Convert.ToDouble(input), CType), typeof(TValidator));
                case DataType.DateTime:
                    return (TValidator)Convert.ChangeType(new DateTimeCompareValidator(Convert.ToDateTime(input), CType), typeof(TValidator));
                case DataType.String:
                    return (TValidator)Convert.ChangeType(new StringCompareValidator(Convert.ToString(input), CType), typeof(TValidator));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
