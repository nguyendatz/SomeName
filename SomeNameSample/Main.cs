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
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var m = new Model();

            // Get data
            m.Email = txtEmail.Text;
            m.RepeatEmail = txtRepeatEmail.Text;

            if (m.IsValid())
            {
                // Do somethings
            }
        }

        public bool EmailExists(object input, object[] Params)
        {
            return input.ToString() != Params[0].ToString();
        }
    }
}