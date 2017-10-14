using System;

namespace WolfGamesSite.DAL.Models
{
    /// <summary>
    /// The default error view model
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// The id of the request that had the error
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Allow the request id to be displayed without error even if
        /// it is empty
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}