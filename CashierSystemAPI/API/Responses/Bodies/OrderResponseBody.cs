/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Body for a <see cref="OrderResponse"/>
    /// </summary>
    public class OrderResponseBody
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public Order Order { get; set; }
    }
}
