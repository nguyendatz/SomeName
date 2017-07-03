using SomeName.Processor;
using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class CompareValidator<TValue> : ValidatorDecorator<TValue>
    {
        private TValue _other;
        private Comparison _cType;

        public TValue Other
        {
            get
            {
                return _other;
            }

            set
            {
                _other = value;
            }
        }

        public Comparison CType
        {
            get
            {
                return _cType;
            }

            set
            {
                _cType = value;
            }
        }

        protected CompareValidator(TValue other, Comparison CType)
        {
            _other = other;
            _cType = CType;
        }

        protected CompareValidator(TValue other, Comparison CType, IValidator<TValue> validator) : base(validator)
        {
            _other = other;
            _cType = CType;
        }

        public override bool IsValid(TValue input, Context context, string propName)
        {
            bool valid = Check(input);

            if (!valid)
            {
                context.AddError(propName, GetErrorMessage());
            }

            if (validator != null)
            {
                return valid && validator.IsValid(input, context, propName);
            }

            return valid;
        }

        public override bool IsValid(TValue input)
        {
            bool valid = Check(input);
            if (validator != null)
            {
                return valid && validator.IsValid(input);
            }
            return valid;
        }

        private bool Check(TValue input)
        {
            bool valid;
            switch (CType)
            {
                case Comparison.Equal:
                    valid = this.Equal(input);
                    break;
                case Comparison.GreaterThan:
                    valid = this.GreaterThan(input);
                    break;
                case Comparison.GreaterThanEqual:
                    valid = this.GreaterThanEqual(input);
                    break;
                case Comparison.LessThan:
                    valid = this.LessThan(input);
                    break;
                case Comparison.LessThanEqual:
                    valid = this.LessThanEqual(input);
                    break;
                case Comparison.NotEqual:
                    valid = this.NotEqual(input);
                    break;
                default:
                    valid = false;
                    break;
            }
            return valid;
        }

        abstract protected bool Equal(TValue input);
        abstract protected bool GreaterThan(TValue input);
        abstract protected bool GreaterThanEqual(TValue input);
        abstract protected bool LessThan(TValue input);
        abstract protected bool LessThanEqual(TValue input);
        abstract protected bool NotEqual(TValue input);
        abstract protected string GetErrorMessage();
    }
}
