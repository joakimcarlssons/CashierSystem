/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Data;
    using System.Collections;
    using System.Data.SqlClient;
    using Dapper;
    using System.Threading.Tasks;
    using System.Linq;
    using System;

    /// <summary>
    /// Implementation of the <see cref="IRepository"/> for Microsoft SQL Server
    /// </summary>
    public class MSSQL : IRepository
    {
        /// <summary>
        /// <see cref="IRepository.Connect"/>
        /// </summary>
        public IDbConnection Connect()
        {
            // Create the connection
            var Connection = new SqlConnection("Data Source=DESKTOP-LCJR5AI;Initial Catalog=CashierSystem;Integrated Security=True");

            // Return the connection
            return Connection;
        }

        #region Private functions

        /// <summary>
        /// Hybrid function to remove duplicate code
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="login">if set to <c>true</c> [login].</param>
        /// <returns></returns>
        private async Task<DBUserResult> LoginCreate(string phoneNumber, int PIN, bool login = true)
        {
            // Try to create the new user...
            try
            {
                // Open a connection to the MSSQl database
                using (var connection = Connect())
                {
                    // Excecute the stored procedure
                    var res = (await connection.QueryAsync<DBUserResult>(
                        (login) ? "LoginUser" : "CreateUser", 
                        new { PhoneNumber = phoneNumber, PIN = PIN }, 
                        commandType: CommandType.StoredProcedure)).First();

                    // Get the result
                    return res;
                }
            }
            // If something failed...
            catch
            {
                // Return false result
                return new DBUserResult() { Result = QueryResults.APIError }; 
            }
        }

        #endregion

        // Functions for the menu controller
        #region User controller

        /// <summary>
        /// <see cref="IRepository.CreateUser(User)"/>
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<DBUserResult> CreateUser(string phoneNumber, int PIN)
        {
            // Create user and return result
            return await LoginCreate(phoneNumber, PIN, false);
        }

        /// summary>
        /// <see cref="IRepository.LoginUser(User)"/>
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<DBUserResult> LoginUser(string phoneNumber, int PIN)
        {
            // Login the user and return result
            return await LoginCreate(phoneNumber, PIN);
        }

        #endregion

        // Functions for the menu controller
        #region Menu controller

        /// <summary>
        /// <see cref="IRepository.GetMenu(int)"/>
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable> GetMenu(int userID)
        {
            // Try to update the item to the database
            try
            {
                // Open a new connection to the database
                using (var connection = Connect())
                {
                    // Get the result from the database
                    var res = await connection.QueryAsync<Item>(
                        "GetMenu",
                        // Create parameters
                        new { SellerID = userID }
                        ,
                        commandType: CommandType.StoredProcedure);

                    // Return the result
                    return res;
                }
            }
            // If query failed on the API level
            catch
            {
                // Return a new status code 'API error'
                return null;
            }
        }

        #endregion

        // Functions for the item controller
        #region Item controller

        /// <summary>
        /// <see cref="IRepository.AddItem(Item)"/>
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<DbStatusResult> AddItem(Item item)
        {
            // Try to update the item to the database
            try
            {
                // Open a new connection to the database
                using (var connection = Connect())
                {
                    // Get the result from the database
                    var res = (await connection.QueryAsync<DbStatusResult>(
                        "AddItem",
                        // Create parameters
                        new
                        {
                            Name = item.Name,
                            Stock = item.Stock,
                            Price = item.Price,
                            SellerID = item.SellerID,
                            Image = item.Image,
                            Description = item.Description
                        }
                        ,
                        commandType: CommandType.StoredProcedure)).First();

                    // Return the result
                    return res;
                }
            }
            // If query failed on the API level
            catch
            {
                // Return a new status code 'API error'
                return new DbStatusResult() { Result = QueryResults.APIError };
            }
        }

        /// <summary>
        /// <see cref="IRepository.DeleteItem(int)"/>
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<DbStatusResult> DeleteItem(int itemID)
        {
            // Try to remove the item
            try
            {
                // Open a connection to the MSSQl database
                using (var connection = Connect())
                {
                    // Excecute the stored procedure
                    var res = (await connection.QueryAsync<DbStatusResult>(
                        "RemoveItem",
                        new { ItemID = itemID },
                        commandType: CommandType.StoredProcedure)).First();

                    // Get the result
                    return res;
                }
            }
            // If something failed...
            catch
            {
                // Return false result
                return new DbStatusResult() { Result = QueryResults.APIError };
            }
        }

        /// <summary>
        /// <see cref="IRepository.UpdateItem(Item)"/>
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<Item> UpdateItem(Item item)
        {
            // Try to update the item to the database
            try
            {
                // Open a new connection to the database
                using (var connection = Connect())
                {
                    // Get the result from the database
                    var res = (await connection.QueryAsync<Item>(
                        "UpdateItem",
                        // Create parameters
                        new
                        {
                            ItemID = item.ItemID,
                            Name = item.Name,
                            Stock = item.Stock,
                            Price = item.Price,
                            Image = item.Image,
                            Description = item.Description
                        }
                        ,
                        commandType: CommandType.StoredProcedure)).First();

                    // Return the result
                    return res;
                }
            }
            // If query failed on the API level
            catch
            {
                // Return a new status code 'API error'
                return null;
            }
        }

        #endregion

    }
}
