using System;
using System.Windows.Forms;

namespace SomeName
{
    public class CustomAttribute : SomeName
    {
        public string Method { get; set; }

        private Form Form { get; set; }

        public CustomAttribute()
        {
            Form = Application.OpenForms[0];
        }

        public override bool IsValid(object input)
        {
            var res = false;
            try
            {
                var tmp = Form.GetType().GetMethod(Method).Invoke(Form, new[] { input });
                bool.TryParse(tmp.ToString(), out res);
            }
            catch(Exception ex)
            {

            }

            return res;
        }
    }
}