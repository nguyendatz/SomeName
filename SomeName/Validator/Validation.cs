using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Validator
{
    public abstract class Validation
    {
        protected List<ValidationGroup> _ValidationGroupList;

        public void attach(ValidationGroup vg)
        {
            _ValidationGroupList.Add(vg);
        }

        public void detach(ValidationGroup vg)
        {
            _ValidationGroupList.Remove(vg);
        }

        abstract public bool isValid();
    }
}
