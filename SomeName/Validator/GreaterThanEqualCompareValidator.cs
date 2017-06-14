using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    class GreaterThanEqualCompareValidator : CompareValidator
    {
        public GreaterThanEqualCompareValidator(object input1, object input2, DataType DType)
        {
            _input1 = input1;
            _input2 = input2;
            _DType = DType;
        }
        protected override bool SoSanh()
        {
            switch (_DType)
            {
                case DataType.Char:
                    return (char)_input1 >= (char)_input2;
                case DataType.Double:
                    return (double)_input1 >= (double)_input2;
                case DataType.Integer:
                    return (int)_input1 >= (int)_input2;
                case DataType.String:
                    return false;
                case DataType.DateTime:
                    return (DateTime)_input1 >= (DateTime)_input2;
                default:
                    return false;
            }
        }
    }
}
