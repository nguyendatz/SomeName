using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeName;
using SomeName.Processor;
using SomeName.Validator;
using SomeName.Util;

namespace SomeNameTest
{
    [TestClass]
    public class NormalProcessorTest
    {
        [TestMethod]
        public void DoValidate_ValidValue_ValidateSuccess()
        {
            IProcessor<object> processor = new NormalProcessor<object>();
            ValidationResult result = processor
                .On(12.3, new DoubleRangeValidator(1.0, 13.3))
                .On(10, new IntegerRangeValidator(1, 13))
                .On(new DateTime(1995, 1, 1), new DateTimeRangeValidator(new DateTime(1000, 1, 1), new DateTime(2017, 6, 14)))
                .On(13.9, new DoubleCompareValidator(19.2, Comparison.GreaterThan))
                .DoValidate()
                .Result();

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void DoValidate_InvalidValue_ReturnDefaultErrorMessage()
        {
            IProcessor<object> processor = new NormalProcessor<object>();

            ValidationResult result = processor
                .On(-12.3, new DoubleRangeValidator(1.0, 13.3), "iphone_price")
                .On(99, new IntegerRangeValidator(1, 13))
                .On(new DateTime(2995, 1, 1), new DateTimeRangeValidator(new DateTime(1000, 1, 1), new DateTime(2017, 6, 14)))
                .DoValidate()
                .Result();

            string value1 = result.GetError("iphone_price");
            string value2 = result.GetError("dummy");
            string value3 = result.GetError("prop0");
            string value4 = result.GetError("prop1");

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(value1);
            Assert.IsNull(value2);
            Assert.IsNotNull(value3);
            Assert.IsNotNull(value4);
        }
    }
}
