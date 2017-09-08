namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Proxy to isolate Wolf Games code from Microsoft's validation system code
    /// </summary>
    public class WGValidationResult : IWGValidationResult
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WGValidationResult(string errorMessage)
        {
        }
    }
}