using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Processor;
using System.Text.RegularExpressions;

namespace SomeName.Validator
{
    public class RegexValidator : ValidatorDecorator<string>
    {
        private string pattern;

        public RegexValidator(string pattern)
        {
            this.pattern = pattern;
        }

        public RegexValidator(string pattern, IValidator<string> validator) : base(validator)
        {
            this.pattern = pattern;
        }

        public override bool IsValid(string input, Context context, string propName)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(input);
            if (!match.Success)
            {
                context.AddError(propName, "Field not match regex.");
            }
            if (validator != null)
            {
                return match.Success && validator.IsValid(input, context, propName);
            }
            return match.Success;
        }

        public override bool IsValid(string input)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(input);
            if (validator != null)
            {
                return match.Success && validator.IsValid(input);
            }
            return match.Success;
        }
    }
}
