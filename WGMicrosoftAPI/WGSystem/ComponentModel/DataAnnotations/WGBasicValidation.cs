using System;
using System.Collections.Generic;
using System.Text;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Base class for the Wolf Games bridge to model validation objects
    /// </summary>
    public class WGBasicValidation : IWGValidation
    {
        /// <summary>
        /// Implementation associated with this client validation.
        /// Use constructor injection to provide your desired implementation.
        /// </summary>
        IWGValidationImplementation IValidationImplementation { get; set; }

        /// <summary>
        /// Create an instance of a WGBasicValidation bridge to a third part
        /// model validation implementation
        /// </summary>
        /// <param name="validationImplementation">A concrete implementation of a model validation system</param>
        public WGBasicValidation(IWGValidationImplementation validationImplementation)
        {
            IValidationImplementation = validationImplementation ?? throw new ArgumentException();
        }
    }
}
