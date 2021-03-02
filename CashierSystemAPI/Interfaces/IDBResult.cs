/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Describes a database result
    /// </summary>
    public interface IDBResult
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public QueryResults Result { get; }
    }
}
