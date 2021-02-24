/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Query results
    /// </summary>
    public enum QueryResults
    {
        #region Normal errors

        /// <summary>
        /// Successful execution.
        /// </summary>
        Successful = 0,
        /// <summary>
        /// The row already exists in the database
        /// </summary>
        RowAlreadyExists = 1,
        /// <summary>
        /// The row was not found in the databaseSuccessful execution.
        /// </summary>
        RowNotFound = 2,
        /// <summary>
        /// The data mismatch
        /// </summary>
        DataMismatch = 3,

        #endregion

        #region Gets returned when exceptions occurred

        /// <summary>
        /// Error occurred on the database layer
        /// </summary>
        SQLError = 100,
        /// <summary>
        /// Error occurred on the API layer
        /// </summary>
        APIError = 200

        #endregion
    }
}
