using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class CompareValidator : Validation
    {
        protected object _input1;
        protected object _input2;
        protected DataType _DType;
        public object Input1
        {
            get
            {
                return _input1;
            }

            set
            {
                _input1 = value;
            }
        }

        public object Input2
        {
            get
            {
                return _input2;
            }

            set
            {
                _input2 = value;
            }
        }

        protected DataType DType
        {
            get
            {
                return _DType;
            }

            set
            {
                _DType = value;
            }
        }

        protected CompareValidator() { }

        public static Validation Create(object input1, object input2, Comparison CType, DataType DType)
        {
            switch (CType)
            {
                case Comparison.Equal:
                    return new EqualCompareValidator(input1, input2, DType);
                case Comparison.NotEqual:
                    return new NotEqualCompareValidator(input1, input2, DType);
                case Comparison.GreaterThan:
                    return new GreaterThanCompareValidator(input1, input2, DType);
                case Comparison.GreaterThanEqual:
                    return new GreaterThanEqualCompareValidator(input1, input2, DType);
                case Comparison.LessThan:
                    return new LessThanCompareValidator(input1, input2, DType);
                case Comparison.LessThanEqual:
                    return new LessThanEqualCompareValidator(input1, input2, DType);
                default:
                    return new EqualCompareValidator(input1, input2, DType);
            }
        }

        public override bool isValid()
        {
            return this.SoSanh();
        }

        abstract protected bool SoSanh();
    }
}
