using System.Collections.Generic;

namespace SomeName
{
    public class ValidationResult
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        public Dictionary<string, string> Errors
        {
            get
            {
                return this.errors;
            }
        }

        public bool IsValid { get; set; }

        public ValidationResult()
        {
            IsValid = true;
        }

        public void AddError(string name, string message)
        {
            this.errors.Add(name, message);
            IsValid = false;
        }

        public string GetError(string name)
        {
            string value = null;
            errors.TryGetValue(name, out value);
            return value;
        }
    }
}