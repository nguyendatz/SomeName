using System;
using System.Windows.Forms;
using SomeName;

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

            Validator validator = new Validator();

            lb_ValidationResult.Text = "";
            if (showDefaultChecked) validator = new Validator();
            else validator = new MyValidator(lb_ValidationResult);
            
            if (validator.IsValid(m))
            {
                // Do somethings
            }
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