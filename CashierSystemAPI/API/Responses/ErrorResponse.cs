/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// The error response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        public Error Error { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        public ErrorResponse(short code, string message)
        {
            // Create the error
            this.Error = new Error
            {
                Code    = code,
                Message = message
            };
        }
    }
}
