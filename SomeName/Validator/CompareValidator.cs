using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class CompareValidator<T> : IValidator
    {
        private T _Input;
        private Comparison _cType;

        public T Input
        {
            get
            {
                return _Input;
            }

            set
            {
                _Input = value;
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

        protected CompareValidator(T input, Comparison CType)
        {
            _Input = input;
            _cType = CType;
        }

        public override bool IsValid<type>(type other)
        {
            switch(CType)
            {
                case Comparison.Equal:
                    return this.Equal(other);
                case Comparison.GreaterThan:
                    return this.GreaterThan(other);
                case Comparison.GreaterThanEqual:
                    return this.GreaterThanEqual(other);
                case Comparison.LessThan:
                    return this.LessThan(other);
                case Comparison.LessThanEqual:
                    return this.LessThanEqual(other);
                case Comparison.NotEqual:
                    return this.NotEqual(other);
                default:
                    return false;
            }
        }

        abstract protected bool Equal(object other);
        abstract protected bool GreaterThan(object other);
        abstract protected bool GreaterThanEqual(object other);
        abstract protected bool LessThan(object other);
        abstract protected bool LessThanEqual(object other);
        abstract protected bool NotEqual(object other);
    }
}
