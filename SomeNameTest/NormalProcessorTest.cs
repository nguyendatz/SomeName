using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeName;
using SomeName.Processor;
using SomeName.Validator;

namespace SomeNameTest
{
    [TestClass]
    public class NormalProcessorTest
    {
        [TestMethod]
        public void DoValidate_DoubleRangeValidator_IsValid()
        {
            IProcessor<double> processor = new NormalProcessor<double>();
            ValidationResult result = processor.On(12, new DoubleRangeValidator(1.0, 13.3))
                .DoValidate()
                .Result();

            Assert.IsTrue(result.IsValid);
        }
    }
}
