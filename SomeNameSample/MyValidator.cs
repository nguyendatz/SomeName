using System;
using System.Windows.Forms;
using SomeName;

namespace SomeNameSample
{
    public class MyValidator : Validator
    {
        public Label LabelResult;
        public MyValidator(Label labelShowResult)
        {
            LabelResult = labelShowResult;
        }
        //public override ValidateResult Validate(object obj)
        //{
        //    var res = new ValidateResult();

        //    Model m = obj as Model;
        //    if(m != null)
        //    {
        //        if(m.Email.Length < 20)
        //        {
        //            var err = "Email's length is less than 20 characters.";
        //            res.Error.Add("MMM", err);
        //        }
        //    }
        //    else
        //    {
        //        var err = "This object is not Model class.";
        //        res.Error.Add("MMM", err);
        //    }

        //    if (res.Error.Count <= 0) res.IsValid = true;
        //    else res.IsValid = false;

        //    return res;
        //}

        public override void ShowErrorForUser(ValidateResult res)
        {
            LabelResult.Text = "";
            if (res.IsValid)
            {
                LabelResult.Text = "Sucess!";
            }
            else
            {
                foreach (var a in res.Error)
                {
                    LabelResult.Text += a.Value + "\n";
                }
            }
        }
    }
}
