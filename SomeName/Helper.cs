using System.Windows.Forms;

namespace SomeName
{
    public static class Helper
    {
        public static bool IsValid<T>(this T obj) where T : class
        {
            var res = new ValidateResult();
            var properties = obj.GetType().GetProperties();

            foreach (var a in properties)
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

            if (res.IsValid)
            {
                MessageBox.Show("Sucess!");
            }
            else
            {
                foreach (var a in res.Error)
                {
                    MessageBox.Show(a.Value);
                }
            }

            return res.IsValid;
        }
    }
}