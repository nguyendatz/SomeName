using System;
using System.Windows.Forms;

namespace SomeName
{
    public class CustomAttribute : SomeName
    {
        public string Method { get; set; }

        public object[] Params { get; set; }

        private Form Form { get; set; }

        public CustomAttribute(string FormName = null)
        {
            Form = FormName == null ? Application.OpenForms[0] : Application.OpenForms[FormName];
        }

        public override bool IsValid(object[] input)
        {
            var res = false;
            try
            {
                var obj = Params == null ? new[] { input } : new[] { input, Params };
                var tmp = Form.GetType().GetMethod(Method).Invoke(Form, obj);
                bool.TryParse(tmp.ToString(), out res);
            }
            catch (Exception ex)
            {

            }

            return res;
        }
    }
}