using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Validator;

namespace SomeName
{
    abstract public class ValidationGroup<T>
    {
        protected List<IValidator> _list;
        protected T _input;

        protected T Input
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

        public ValidationGroup(T input)
        {
            _input = input;
            _list = new List<IValidator>();
        }

        public void add(IValidator v)
        {
            _list.Add(v);
        }

        public void remove(IValidator v)
        {
            _list.Remove(v);
        }

        protected abstract bool isValid();
    }
}
