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
            ErrorMessage = errorMessage;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if(ErrorMessage != ((WGValidationResult)obj).ErrorMessage)
            {
                return false;
            }

            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                if (ErrorMessage != null)
                {
                    hash = hash * 23 + ErrorMessage.GetHashCode();
                }

                return hash + base.GetHashCode();
            }
        }
    }
}