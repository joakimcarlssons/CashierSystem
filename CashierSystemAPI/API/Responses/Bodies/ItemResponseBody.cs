/// <summary>
/// Root namespaces
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Body for when items are CRUD'ed
    /// </summary>
    public class ItemResponseBody
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The <see cref="Item"/>
        /// </value>
        public Item Item { get; set; }
    }
}
