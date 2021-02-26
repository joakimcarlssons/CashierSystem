/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// A normal API response
    /// </summary>
    /// <seealso cref="CashierSystemAPI.IResponse" />
    public class OKResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public object Response { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OKResponse"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public OKResponse(object response)
        {
            // Set the response
            this.Response = response;
        }
    }
}
