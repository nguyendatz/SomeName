using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    class OrValidationGroup<T> : ValidationGroup<T>
    {
        public OrValidationGroup(T input) : base(input)
        {
        }

        protected override bool isValid()
        {
            bool result = _list[0].isValid<T>(_input);
            for (int i = 1; i < _list.Count; i++)
                result = result || _list[i].isValid<T>(_input);
            return result;
        }
    }
}
