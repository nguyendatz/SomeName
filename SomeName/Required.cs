﻿namespace SomeName
{
    public class RequiredAttribute : SomeName
    {
        public override void IsValid(object[] input)
        {
            var sInput = input[0].ToString().Trim();
            //return !string.IsNullOrEmpty(sInput);
        }
    }
}