using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    abstract class RangeValidation : Validation
    {
        protected object _min;
        protected object _max;
        protected object _input;

        public object Min
        {
            get
            {
                return _min;
            }

            set
            {
                _min = value;
            }
        }

        public object Max
        {
            get
            {
                return _max;
            }

            set
            {
                _max = value;
            }
        }

        public object Input
        {
            get
            {
                return _input;
            }

            set
            {
                _input = value;
            }
        }

        protected RangeValidation(object input, object min, object max)
        {
            _min = min;
            _max = max;
            _input = input;
        }

        static public Validation Create(object input, object min, object max, DataType type)
        {
            switch(type)
            {
                case DataType.Integer:
                    return new IntegerRangeValidation(input, min, max);
                case DataType.Double:
                    return new DoubleRangeValidation(input, min, max);
                case DataType.DateTime:
                    return new DateTimeRangeValidation(input, min, max);
                default:
                    return new IntegerRangeValidation(input, min, max);
            }
        }

        public override bool isValid()
        {
            return this.SoSanh();
        }

        abstract protected bool SoSanh();
    }

    public class Class1
    {
    }
}
