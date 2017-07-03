using System;
using System.Windows.Forms;
using SomeName;
using System.Collections.Generic;

namespace SomeNameSample
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            showDefaultChecked = true;
            rb_ShowDefault.Checked = true;
        }
        bool showDefaultChecked = true;


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var m = new Model();

            // Get data
            m.FullName = txtFullName.Text;
            m.Username = txtUsername.Text;
            m.Email = txtEmail.Text;
            m.Password = txtPassword.Text;
            m.ConfirmPassword = txtConfirmPassword.Text;

            Validator validator;

            lb_ValidationResult.Text = "";
            if (showDefaultChecked)
                validator = new Validator();
            else
                validator = new MyValidator(lb_ValidationResult);

            if (validator.IsValid(m))
            {
                // Do somethings
            }

            //Dictionary<string, List<string>> Data = new Dictionary<string, List<string>>();

            //Data.Add("Test1", new List<string>());
            //Data["Test1"].Add("Error1");
            //Data["Test1"].Add("Error2");
            //Data["Test1"].Add("Error3");

            //Data.Add("Test2", new List<string>());
            //Data["Test2"].Add("Error1");
            //Data["Test2"].Add("Error2");
            //Data["Test2"].Add("Error3");

            //ShowFormat f = new ShowFile("TestLog.txt");
            //f.Show(Data);
        }

        public static bool EmailExists(object input, object[] Params)
        {
            return input.ToString() != Params[0].ToString();
        }

        private void rb_ShowDefault_CheckedChanged(object sender, EventArgs e)
        {
            showDefaultChecked = true;
        }

        private void rb_ShowCustom_CheckedChanged(object sender, EventArgs e)
        {
            showDefaultChecked = false;
        }
    }
}