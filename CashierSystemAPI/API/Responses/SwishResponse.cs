/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Swish response
    /// </summary>
    public class SwishResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public SwishResponseBody Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwishResponse"/> class.
        /// </summary>
        /// <param name="QR">The qr.</param>
        /// <param name="reqJson">The req json.</param>
        public SwishResponse(string qR, Swish req)
        {
            // Create the response
            this.Response = new SwishResponseBody()
            {
                QR = qR,
                RequestData = req
            };
        }
    }
}
