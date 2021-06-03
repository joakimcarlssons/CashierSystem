/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Runtime.Serialization;

    /// <summary>
    /// Query results
    /// </summary>
    public enum QueryResults
    {
        #region Normal errors

        /// <summary>
        /// Successful execution.
        /// </summary>
        [EnumMember(Value = "Query was successful")]
        Successful = 0,
        /// <summary>
        /// The row already exists in the database
        /// </summary>
        [EnumMember(Value = "Data already exists")]
        RowAlreadyExists = 1,
        /// <summary>
        /// The row was not found in the databaseSuccessful execution.
        /// </summary>
        [EnumMember(Value = "Data was not found")]
        RowNotFound = 2,
        /// <summary>
        /// The data mismatch
        /// </summary>
        [EnumMember(Value = "Invalid query")]
        Invalid = 3,

        #endregion

        #region Gets returned when exceptions occurred

        /// <summary>
        /// Error occurred on the database layer
        /// </summary>
        [EnumMember(Value = "SQL side error")]
        SQLError = 100,
        /// <summary>
        /// Error occurred on the API layer
        /// </summary>
        [EnumMember(Value = "API side error")]
        APIError = 200

        #endregion
    }
}
