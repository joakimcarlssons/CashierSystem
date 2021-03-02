/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Contains only a status on the query
    /// </summary>
    public class DBResult : IDBResult
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public QueryResults Result { get; set; }
    }
}
