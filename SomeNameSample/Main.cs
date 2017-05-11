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

            var validateResult = m.IsValid();

            if(validateResult.IsValid)
            {
                MessageBox.Show("Sucess!");
            }
            else
            {
                // Show errors
                foreach (var a in validateResult.Error)
                {
                    MessageBox.Show(a.Value);
                }
            }
        }
    }
}