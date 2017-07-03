using System;
using System.Windows.Forms;
using SomeName;
using SomeName.Util;
using SomeName.Validator;

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
            var m = new User();

            // Get data
            m.Username = txtUsername.Text;

            IValidator<User> validator = new ModelValidator<User>();
            validator.IsValid(m);
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