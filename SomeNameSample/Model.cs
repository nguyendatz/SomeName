using SomeName;
using SomeName.Util;
using SomeName.Annotation;

namespace SomeNameSample
{
    public class Model
    {
        public string Email { get; set; }

        [Compare(CompareTo = "Email", ComparisonType = Comparison.Equal, Type = DataType.String)]
        public string RepeatEmail { get; set; }
    }
}