using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    class AndValidationGroup<T> : ValidationGroup<T>
    {
        public AndValidationGroup(T input) : base(input)
        {
        }

        protected override bool isValid()
        {
            bool result = _list[0].IsValid<T>(_input);
            for (int i = 1; i < _list.Count; i++)
                result = result && _list[i].IsValid<T>(_input);
            return result;
        }
    }
}
