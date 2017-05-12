using System;
using System.Collections.Generic;

namespace SomeName
{
    public abstract class SomeName: Attribute
    {
        public abstract bool IsValid(object input);

        public string ErrorMessage { get; set; }

        public object Pattern { get; set; }
    }

    public class ValidateResult
    {
        public ValidateResult()
        {
            Error = new Dictionary<string, string>();
        }

        public bool IsValid { get; set; }

        public Dictionary<string, string> Error { get; set; }
    }

    public static class Helper
    {
        public static ValidateResult IsValid<T>(this T obj) where T: class
        {
            var res = new ValidateResult();
            var properties = obj.GetType().GetProperties();

            foreach(var a in properties)
            {
                var atts = a.GetCustomAttributes(typeof(SomeName), true);
                res.IsValid = true;

                foreach (SomeName att in atts)
                {
                    res.IsValid = att.IsValid(a.GetValue(obj));

                    if (!res.IsValid)
                    {
                        var err = att.ErrorMessage ?? string.Format("The field {0} is not valid.", a.Name);
                        res.Error.Add(a.Name, err);
                        break;
                    }
                }
            }

            return res;
        }
    }
}