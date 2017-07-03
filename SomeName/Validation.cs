using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    abstract public class Validation
    {
        protected List<ValidationGroup> _ValidationGroupList;

        public void attach(ValidationGroup vg)
        {
            _ValidationGroupList.Add(vg);
            vg.add(this);
        }

        public void detach(ValidationGroup vg)
        {
            _ValidationGroupList.Remove(vg);
            vg.remove(this);
        }

        abstract public bool isValid();
    }
}
