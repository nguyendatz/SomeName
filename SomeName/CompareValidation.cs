using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public abstract class CompareValidation : Validation
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

        protected CompareValidation() { }

        public static CompareValidation Create(object input1, object input2, Comparison CType, DataType DType)
        {
            switch (CType)
            {
                case Comparison.Equal:
                    return new EqualCompareValidation(input1, input2, DType);
                case Comparison.NotEqual:
                    return new NotEqualCompareValidation(input1, input2, DType);
                case Comparison.GreaterThan:
                    return new GreaterThanCompareValidation(input1, input2, DType);
                case Comparison.GreaterThanEqual:
                    return new GreaterThanEqualCompareValidation(input1, input2, DType);
                case Comparison.LessThan:
                    return new LessThanCompareValidation(input1, input2, DType);
                case Comparison.LessThanEqual:
                    return new LessThanEqualCompareValidation(input1, input2, DType);
                default:
                    return new EqualCompareValidation(input1, input2, DType);
            }
        }

        public override bool isValid()
        {
            return this.SoSanh();
        }

        abstract protected bool SoSanh();
    }
}
