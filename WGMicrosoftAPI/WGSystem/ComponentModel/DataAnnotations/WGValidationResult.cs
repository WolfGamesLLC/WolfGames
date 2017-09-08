namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Adaptor to isolate Wolf Games code from Microsoft's validation system code
    /// </summary>
    public class WGValidationResult : IWGValidationResult
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WGValidationResult()
        {
        }
    }
}