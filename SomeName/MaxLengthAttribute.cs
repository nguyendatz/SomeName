using System;

namespace SomeName
{
    public class MaxLengthAttribute : SomeName
    {
        public int Length { get; set; }
        public override bool IsValid(object[] input)
        {
            return (input[0].ToString().Length > Length) ? false : true;
        }
    }
}
