//using SomeName.Annotation;
//using System.Windows.Forms;

//namespace SomeName.Util
//{
//    public static class Helper
//    {
//        public static bool IsValid<T>(this T obj, MessageType type = MessageType.MessageBox) where T : class
//        {
//            var res = Validate(obj);
//            ShowError(res, type);

//            return res.IsValid;
//        }

//        public static ValidationResult Validate<T>(T obj)
//        {
//            var res = new ValidationResult();
//            var properties = obj.GetType().GetProperties();

//            foreach (var a in properties)
//            {
//                var atts = a.GetCustomAttributes(typeof(SomeNameAttribute), true);
//                res.IsValid = true;

//                foreach (SomeNameAttribute att in atts)
//                {
//                    if (att.ToString() == "SomeName.Annotation.CompareAttribute")
//                    {
//                        foreach (var b in properties)
//                        {
//                            if (((CompareAttribute)att).CompareTo == b.Name)
//                            {
//                                res.IsValid = att.IsValid(new object[] { a.GetValue(obj), b.GetValue(obj) });
//                                break;
//                            }
//                        }
//                    }
//                    else
//                        res.IsValid = att.IsValid(new object[] { a.GetValue(obj) } );

//                    if (!res.IsValid)
//                    {
//                        var err = att.ErrorMessage ?? string.Format("The field {0} is not valid.", a.Name);
//                        res.Errors.Add(a.Name, err);
//                        break;
//                    }
//                }
//            }

//            return res;
//        }

//        private static void ShowError(ValidationResult res, MessageType type)
//        {
//            switch (type)
//            {
//                case MessageType.MessageBox:
//                    if (res.IsValid)
//                    {
//                        MessageBox.Show("Sucess!");
//                    }
//                    else
//                    {
//                        foreach (var a in res.Errors)
//                        {
//                            MessageBox.Show(a.Value);
//                        }
//                    }
//                    break;

//                default:
//                    break;
//            }
//        }
//    }
//}