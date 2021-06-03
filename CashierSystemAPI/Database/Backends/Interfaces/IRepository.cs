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
        public abstract Task<DBUserResult> CreateUser(string phoneNumber, int PIN);

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public abstract Task<DBUserResult> LoginUser(string phoneNumber, int PIN);

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
        public abstract Task<DBResult> AddItem(Item item);

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="itemID">The item identifier.</param>
        /// <returns></returns>
        public abstract Task<DBResult> DeleteItem(int itemID);

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public abstract Task<DBItemResult> UpdateItem(Item item);

        #endregion

        // Functions for the order controller
        #region Order controller

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="order">The <see cref="Order"/>.</param>
        /// <returns></returns>
        public Task<DBOrderResult> CreateOrder(PostOrder order);

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderID">The order identifier.</param>
        /// <returns>The <see cref="Order"/></returns>
        public Task<DBOrderResult> GetOrder(int orderID);

        /// <summary>
        /// Deltets the order
        /// </summary>
        /// <param name="orderID">The order identifier.</param>
        /// <returns>The <see cref="Order"/></returns>
        public Task<DBResult> DeleteOrder(int orderID);

        #endregion
    }
}
