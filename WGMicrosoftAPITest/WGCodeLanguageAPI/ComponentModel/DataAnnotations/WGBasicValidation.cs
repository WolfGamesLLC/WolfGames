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
        IWGValidationImplementation iWGValidationImplementation { get; set; }
    }
}
