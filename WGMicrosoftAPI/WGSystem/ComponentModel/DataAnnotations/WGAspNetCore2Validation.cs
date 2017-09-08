using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Implementation of ASP.Net Core 2.0 model validation 
    /// </summary>
    public class WGAspNetCore2Validation : IWGValidationImplementation
    {
        /// <summary>
        /// Return the results of the Validator.TryValidateObject call
        /// </summary>
        public IEnumerable<IWGValidationResult> Result { get => throw new NotImplementedException(); }

        /// <summary>
        /// Setup and call Validator.TryValidateObject
        /// </summary>
        /// <param name="model">The model to be verified</param>
        /// <returns>True if the model passes</returns>
        public bool TryValidateObject(object model)
        {
            throw new NotImplementedException();
        }
    }
}
