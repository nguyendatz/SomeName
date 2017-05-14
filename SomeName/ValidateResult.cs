using System.Collections.Generic;

namespace SomeName
{
    public class ValidateResult
    {
        public ValidateResult()
        {
            Error = new Dictionary<string, string>();
        }

        public bool IsValid { get; set; }

        public Dictionary<string, string> Error { get; set; }
    }
}