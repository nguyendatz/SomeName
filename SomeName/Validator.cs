using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SomeName
{
    public class Validator
    {
        //Template method include 3 step
        public bool IsValid(Object obj)
        {
            //1. validate
            var res = Validate(obj);

            //2.show msg for dev
            ShowErrorForDev(res);

            //3. show msg for user
            ShowErrorForUser(res);

            return res.IsValid;
        }

        //Default: use attribute
        public virtual ValidateResult Validate(Object obj)
        {
            var res = new ValidateResult();
            res.IsValid = true;
            var properties = obj.GetType().GetProperties();

            foreach (var a in properties)
            {
                var atts = a.GetCustomAttributes(typeof(SomeName), true);
                var rlt = true;

                /*foreach (SomeName att in atts)
                {
                    if (att.ToString() == "SomeName.CompareAttribute")
                    {
                        foreach (var b in properties)
                        {
                            if (((CompareAttribute)att).CompareTo == b.Name)
                            {
                                rlt = att.IsValid(new object[] { a.GetValue(obj), b.GetValue(obj) });
                                break;
                            }
                        }
                    }
                    else
                        rlt = att.IsValid(new object[] { a.GetValue(obj) });

                    if (rlt == false)
                    {
                        var err = att.ErrorMessage ?? string.Format("The field {0} is not valid.", a.Name);
                        res.Error.Add(a.Name, err);
                        break;
                    }
                }*/
            }



            if (res.Error.Count > 0) res.IsValid = false;

            return res;
        }

        //Default: use Messagebox
        public virtual void ShowErrorForUser(ValidateResult res)
        {
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
        }

        //Default: use System.Diagnostics.Debug
        public virtual void ShowErrorForDev(ValidateResult res)
        {
            if (res.IsValid)
            {
                Debug.WriteLine("Success!");
            }
            else
            {
                foreach (var a in res.Error)
                {
                    Debug.WriteLine(a.Value);
                }
            }
        }
    }
}
