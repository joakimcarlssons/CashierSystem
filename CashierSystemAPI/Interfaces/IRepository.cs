/// <summary>
/// Root namespce
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Data;
    using System.Collections;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Connect to the database
        /// </summary>
        public abstract IDbConnection Connect();

        // Functions for the menu controller
        #region User controller

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public abstract Task<DBUserResult> CreateUser(User user);

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public abstract Task<DBUserResult> LoginUser(User user);

        #endregion

        // Functions for the menu controller
        #region Menu controller

        /// <summary>
        /// Gets the user's menu.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetMenu(int userID);

        #endregion

        // Functions for the item controller
        #region Item controller

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public abstract Task<DbStatusResult> AddItem(Item item);

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="itemID">The item identifier.</param>
        /// <returns></returns>
        public abstract Task<DbStatusResult> DeleteItem(int itemID);

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public abstract Task<DbStatusResult> UpdateItem(Item item);

        #endregion
    }
}
