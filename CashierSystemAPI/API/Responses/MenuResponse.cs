/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Collections;

    /// <summary>
    /// Reponse for when a manu is queried
    /// </summary>
    public class MenuResponse
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public MenuResponseBody Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuResponse"/> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public MenuResponse(string message, IEnumerable items)
        {
            // Create the body
            this.Response = new MenuResponseBody()
            {
                Message = message,
                Items = items
            };
        }
    }
}
