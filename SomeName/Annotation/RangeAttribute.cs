using SomeName.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Annotation
{
    public class RangeAttribute : SomeNameAttribute
    {
        public object Minimum { get; set; }
        public object Maximum { get; set; }
        public DataType  DataType { get; set; }
    }
}
