/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Collections;

    /// <summary>
    /// Body for a <see cref="MenuResponse"/>
    /// </summary>
    public class MenuResponseBody
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
        public IEnumerable Items { get; set; }
    }
}
