using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class IValidator
    {
        /*protected List<ValidationGroup<T>> _ValidatorGroupList;

        public void attach<T>(ValidationGroup<T> vg)
        {
            _ValidatorGroupList.Add(vg);
        }

        public void detach<T>(ValidationGroup<T> vg)
        {
            _ValidatorGroupList.Remove(vg);
        }*/

        abstract public bool isValid<T>(T input);
    }
}
