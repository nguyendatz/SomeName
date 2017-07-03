using System;
using System.Reflection;
using System.Windows.Forms;

namespace SomeName
{
    public class CustomAttribute : SomeName
    {
        public string Method { get; set; }
        public string Class { get; set; }
        public string Library { get; set; }

        public object[] Params { get; set; }

        public override void IsValid(object[] input)
        {
            var res = false;
            try
            {
                var obj = Params == null ? new[] { input[0] } : new[] { input[0], Params };
               
                Assembly a = Assembly.Load(Library);
                var type = a.GetType(Class);
                var tmp = type.GetMethod(Method).Invoke(null, obj);
                bool.TryParse(tmp.ToString(), out res);
            }
            catch (Exception ex)
            {

            }

            //return res;
        }
    }
}