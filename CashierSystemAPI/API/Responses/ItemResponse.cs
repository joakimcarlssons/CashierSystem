/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// An <see cref="Item"/> response
    /// </summary>
    public class ItemResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The <see cref="ItemResponseBody"/>
        /// </value>
        public ItemResponseBody Response { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemResponse"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="item">The <see cref="Item"/>.</param>
        public ItemResponse(string message, Item item)
        {
            // Create the item response
            this.Response = new ItemResponseBody()
            {
                Message = message,
                Item = item
            };
        }
    }
}
