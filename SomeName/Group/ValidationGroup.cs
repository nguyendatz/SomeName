using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Validator;

namespace SomeName
{
    abstract public class ValidationGroup
    {
        protected List<Validation> _list;

        public ValidationGroup()
        {
            _list = new List<Validation>();
        }

        public void add(Validation v)
        {
            _list.Add(v);
        }

        public void remove(Validation v)
        {
            _list.Remove(v);
        }

        abstract public bool isValid();
    }
}
