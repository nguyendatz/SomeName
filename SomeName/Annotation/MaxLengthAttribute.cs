﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Annotation
{
    public class MaxLengthAttribute : SomeNameAttribute
    {
        public int Length { get; set; }
    }
}
