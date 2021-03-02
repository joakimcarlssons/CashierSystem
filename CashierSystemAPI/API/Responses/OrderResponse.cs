/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Reponse for when a manu is queried
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public OrderResponseBody Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderResponse"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public OrderResponse(string message, Order order)
        {
            // Create the body
            this.Response = new OrderResponseBody()
            {
                Message = message,
                Order = order
            };
        }
    }
}