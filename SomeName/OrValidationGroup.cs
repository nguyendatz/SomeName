using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    class OrValidationGroup : ValidationGroup
    {
        public OrValidationGroup(string name) : base(name)
        {
        }

        public override bool isValid()
        {
            bool result = _list[0].isValid();
            for (int i = 1; i < _list.Count; i++)
                result = result || _list[i].isValid();
            return result;
        }
    }
}
