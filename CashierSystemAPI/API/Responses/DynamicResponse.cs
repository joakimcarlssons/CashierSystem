/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Response for creating a custom Json response
    /// </summary>
    public class DynamicResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public dynamic Response { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicResponse"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public DynamicResponse(dynamic response)
        {
            // Set the response
            this.Response = response;
        }
    }
}
