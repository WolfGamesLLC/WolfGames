using System;
using System.Collections.Generic;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Proxy to isolate Wolf Games code from Microsoft's validation system code
    /// </summary>
    public class WGValidationResult : IWGValidationResult
    {
        /// <summary>
        /// The error message associated with the result
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WGValidationResult(string errorMessage)
        {
            ErrorMessage = errorMessage ?? throw new ArgumentNullException();
        }
    }
}