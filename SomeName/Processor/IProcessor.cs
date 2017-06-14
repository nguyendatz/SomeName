using SomeName.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Processor
{
    /// <summary>
    /// Validation processor can process a batch of validator and perform all validation at once
    /// after that, we can get the result of the validation
    /// </summary>
    /// <typeparam name="TResult">Type of validation result, this can be any type (string, ValidateResult, integer, ...)</typeparam>
    public interface IProcessor<T>
    {
        /// <summary>
        /// Validation result, can be any posible type
        /// </summary>
        ValidationResult Result();

        /// <summary>
        /// Process validation on validation batch
        /// </summary>
        /// <returns>Validation processor</returns>
        IProcessor<T> DoValidate();

        /// <summary>
        /// Add a validator on a value to validation batch
        /// </summary>
        /// <typeparam name="T">Type of validation value</typeparam>
        /// <param name="value">The value we wish to validate</param>
        /// <param name="validator">Validator to perform validation on target value</param>
        /// <returns>Validation processor</returns>
        IProcessor<T> On(T value, IValidator validator);
    }
}
