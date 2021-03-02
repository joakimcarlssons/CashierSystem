/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Result object that gets created and returned when an item is reuturned from the database
    /// </summary>
    public class DBOrderResult : IDBResult
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public QueryResults Result { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        public Order Order { get; set; }

    }
}
