/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Body for a <see cref="SwishResponse"/>
    /// </summary>
    public class SwishResponseBody
    {
        /// <summary>
        /// Gets or sets the qr.
        /// </summary>
        /// <value>
        /// The qr.
        /// </value>
        public string QR { get; set; }

        /// <summary>
        /// Gets or sets the request data.
        /// </summary>
        /// <value>
        /// The request data.
        /// </value>
        public Swish RequestData { get; set; }
    }
}
