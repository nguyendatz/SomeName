using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    abstract public class ValidationGroup
    {
        private string _Name;

        protected List<Validation> _list;

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public ValidationGroup(string name)
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
