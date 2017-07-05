using System;
using System.Windows.Forms;
using SomeName;
using SomeName.Util;
using SomeName.Validator;
using SomeName.Processor;

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

            // Auto validation
            m.Fullname = txtFullName.Text;
            m.Username = txtUsername.Text;
            m.Email = txtEmail.Text;
            m.Password = txtPassword.Text;
            m.ConfirmPassword = txtConfirmPassword.Text;
            m.DOB = dateTimePicker_DOB.Value;

            // uncomment each block of code to view result

            // AUTOMATIC VALIDATION
            AnnotationProcessor processor = new AnnotationProcessor();
            Context context = processor.On(m).Result();
            if (context.HasError())
            {
                context.ShowError(new ShowMsgBox());
            }

            // MANUAL VALIDATION
            //DefaultProcessor defaultProcessor = new DefaultProcessor();
            //Context manualValidationContext = defaultProcessor.On(m.Email, new RequiredValidator<string>(), "email")
            //    .On(m.Email, new RegexValidator(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"), "email")
            //    .On(m.Username, new MinLengthValidator(5), "username")
            //    .Result();
            //if (manualValidationContext.HasError())
            //{
            //    manualValidationContext.ShowError(new ShowMsgBox());
            //}

            // CUSTOM VALIDATION
            //IValidator<string> emailValidator = new RequiredValidator<string>(new RegexValidator(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));
            //DefaultProcessor dp = new DefaultProcessor();
            //Context customValidationContext = dp.On(m.Email, emailValidator, "email").Result();
            //if (customValidationContext.HasError())
            //{
            //    customValidationContext.ShowError(new ShowMsgBox());
            //}
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