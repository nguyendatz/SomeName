using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Processor;
using System.Reflection;
using SomeName.Annotation;
using SomeName.Validator;
using SomeName.Util;

namespace SomeName.Processor
{
    public class AnnotationProcessor : IProcessor
    {
        private Context context = new Context();

        public IProcessor On<TValue>(TValue value)
        {
            var properties = value.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(typeof(SomeNameAttribute), true);
                var propValue = prop.GetValue(value, null);
                var propName = prop.Name;

                foreach (SomeNameAttribute attr in attrs)
                {
                    string message = attr.Message;

                    switch (attr.GetType().Name)
                    {
                        case "RequiredAttribute":
                            ValidateRequired(attr, propName, propValue);
                            break;
                        case "MinLengthAttribute":
                            ValidateMinLength(attr, propName, propValue);
                            break;
                        case "MaxLengthAttribute":
                            ValidateMaxLength(attr, propName, propValue);
                            break;
                        case "RegexAttribute":
                            ValidateRegex(attr, propName, propValue);
                            break;
                        case "CompareAttribute":
                            CompareAttribute compareAttribute = (CompareAttribute)attr;
                            string compareTo = compareAttribute.CompareTo;
                            object otherValue = null;
                            foreach (var other in properties)
                            {   
                                if (other.Name == compareTo)
                                {
                                    otherValue = other.GetValue(value, null);
                                    break;
                                }
                            }

                                ValidateComparision(attr, propName, propValue, otherValue);
                            break;
                        case "RangeAttribute":
                            ValidateRange(attr, propName, propValue);
                            break;
                        case "StringLengthAttribute":
                            ValidateStringLength(attr, propName, propValue);
                            break;
                    }
                }
            }

            return this;
        }

        public Context Result()
        {
            return context;
        }

        private void ValidateRequired(SomeNameAttribute attr, string name, object value)
        {
            RequiredValidator<object> v = new RequiredValidator<object>();
            if (!v.IsValid(value))
            {
                context.AddError(name, attr.Message);
            }
        }

        private void ValidateMinLength(SomeNameAttribute attr, string name, object value)
        {
            MinLengthAttribute minLengthAttribute = (MinLengthAttribute)attr;
            int minLength = minLengthAttribute.Length;
            string strValue = (string)Convert.ChangeType(value, typeof(string));

            ValidatorDecorator<int> v = new IntegerCompareValidator(minLength, Comparison.GreaterThanEqual);

            if (!v.IsValid(strValue.Length))
            {
                context.AddError(name, attr.Message);
            }
        }

        private void ValidateMaxLength(SomeNameAttribute attr, string name, object value)
        {
            MaxLengthAttribute maxLengthAttribute = (MaxLengthAttribute)attr;
            int maxLength = maxLengthAttribute.Length;
            string strValue = (string)Convert.ChangeType(value, typeof(string));

            ValidatorDecorator<int> v = new IntegerCompareValidator(maxLength, Comparison.LessThanEqual);

            if (!v.IsValid(strValue.Length))
            {
                context.AddError(name, attr.Message);
            }
        }

        private void ValidateRegex(SomeNameAttribute attr, string name, object value)
        {
            RegexAttribute regexAttribute = (RegexAttribute)attr;
            string pattern = regexAttribute.Pattern;
            RegexValidator v = new RegexValidator(pattern);
            string strValue = (string)Convert.ChangeType(value, typeof(string));
            if (!v.IsValid(strValue))
            {
                context.AddError(name, attr.Message);
            }
        }

        private void ValidateComparision(SomeNameAttribute attr, string name, object value, object otherValue)
        {
            CompareAttribute compareAttribute = (CompareAttribute)attr;
            Comparison cType = compareAttribute.ComparisonType;

            if (value.GetType().Equals(typeof(string)))
            {
                string strValue = (string)Convert.ChangeType(value, typeof(string));
                string other = (string)Convert.ChangeType(otherValue, typeof(string));
                StringCompareValidator v = new StringCompareValidator(other, cType);
                if (!v.IsValid(strValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
            else if (value.GetType().Equals(typeof(int)))
            {
                int intValue = (int)Convert.ChangeType(value, typeof(int));
                int other = (int)Convert.ChangeType(otherValue, typeof(int));
                IntegerCompareValidator v = new IntegerCompareValidator(other, cType);
                if (!v.IsValid(intValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
            else if (value.GetType().Equals(typeof(double)))
            {
                double doubleValue = (double)Convert.ChangeType(value, typeof(double));
                double other = (double)Convert.ChangeType(otherValue, typeof(double));
                DoubleCompareValidator v = new DoubleCompareValidator(other, cType);
                if (!v.IsValid(doubleValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
            else if (value.GetType().Equals(typeof(DateTime)))
            {
                DateTime dateTimeValue = (DateTime)Convert.ChangeType(value, typeof(DateTime));
                DateTime other = (DateTime)Convert.ChangeType(otherValue, typeof(DateTime));
                DateTimeCompareValidator v = new DateTimeCompareValidator(other, cType);
                if (!v.IsValid(dateTimeValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
        }

        private void ValidateStringLength(SomeNameAttribute attr, string name, object value)
        {
            StringLengthAttribute stringLengthAttribute = (StringLengthAttribute)attr;
            int minLength = stringLengthAttribute.MinimumLength;
            int maxLength = stringLengthAttribute.MaximumLength;
            string strValue = (string)Convert.ChangeType(value, typeof(string));

            ValidatorDecorator<int> v = new IntegerRangeValidator(minLength, maxLength + 1);
            if (!v.IsValid(strValue.Length))
            {
                context.AddError(name, attr.Message);
            }
        }

        private void ValidateRange(SomeNameAttribute attr, string name, object value)
        {
            RangeAttribute rangeAttribute = (RangeAttribute)attr;
            object min = rangeAttribute.Minimum;
            object max = rangeAttribute.Maximum;
            DataType dataType = rangeAttribute.DataType;

            string strValue = (string)Convert.ChangeType(value, typeof(string));


            if (dataType == DataType.Integer)
            {
                int intValue = (int)Convert.ChangeType(value, typeof(int));
                int intMin = (int)Convert.ChangeType(min, typeof(int));
                int intMax = (int)Convert.ChangeType(max, typeof(int));
                IntegerRangeValidator v = new IntegerRangeValidator(intMin, intMax);
                if (!v.IsValid(intValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
            else if (dataType == DataType.Double)
            {
                double doubleValue = (double)Convert.ChangeType(value, typeof(double));
                double doubleMin = (double)Convert.ChangeType(min, typeof(double));
                double doubleMax = (double)Convert.ChangeType(max, typeof(double));
                DoubleRangeValidator v = new DoubleRangeValidator(doubleMin, doubleMax);
                if (!v.IsValid(doubleValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
            else if (dataType == DataType.DateTime)
            {
                DateTime dValue = (DateTime)Convert.ChangeType(value, typeof(DateTime));
                DateTime dMin = (DateTime)Convert.ChangeType(min, typeof(DateTime));
                DateTime dMax = (DateTime)Convert.ChangeType(max, typeof(DateTime));

                DateTimeRangeValidator v = new DateTimeRangeValidator(dMin, dMax);
                if (!v.IsValid(dValue))
                {
                    context.AddError(name, attr.Message);
                }
            }
        }

    }
}
