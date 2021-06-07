/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using Dapper;
    using System;
    using System.Linq;
    using System.Data;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of the <see cref="IRepository"/> for Microsoft SQL Server
    /// </summary>
    public class MSSQL : IRepository
    {
        /// <summary>
        /// <see cref="IRepository.Connect"/>
        /// </summary>
        public SqlConnection Connect()
        {
            // Create the connection
            var Connection = 
                new SqlConnection("Data Source=DESKTOP-LCJR5AI;Initial Catalog=CashierSystem;Integrated Security=True");

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
        public async Task<DBResult> AddItem(Item item)
        {
            // Try to update the item to the database
            try
            {
                // Open a new connection to the database
                using (var connection = Connect())
                {
                    // Open connection
                    await connection.OpenAsync();

                    // Get the result from the database
                    var res = (await connection.QueryMultipleAsync(
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
                        , null, null,
                        commandType: CommandType.StoredProcedure));

                    // Create the return result object
                    var ret = new DBResult();
                    // Set the call status
                    ret.Result = (await res.ReadAsync<QueryResults>()).First();
                    // If item was added
                    if (ret.Result == QueryResults.Successful)
                    {
                        // Set the returned value
                        ret.ReturnedVal = (await res.ReadAsync<int>()).First();
                    }

                    // Return the result
                    return ret;
                }
            }
            // If query failed on the API level
            catch
            {
                // Return a new status code 'API error'
                return new DBResult() { Result = QueryResults.APIError };
            }
        }

        /// <summary>
        /// <see cref="IRepository.DeleteItem(int)"/>
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<DBResult> DeleteItem(int itemID)
        {
            // Try to remove the item
            try
            {
                // Open a connection to the MSSQl database
                using (var connection = Connect())
                {
                    // Excecute the stored procedure
                    var res = (await connection.QueryAsync<DBResult>(
                        "DeleteItem",
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
                return new DBResult() { Result = QueryResults.APIError };
            }
        }

        /// <summary>
        /// <see cref="IRepository.UpdateItem(Item)"/>
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<DBItemResult> UpdateItem(Item item)
        {
            // Create the final result
            var res = new DBItemResult() { Item = null };
            // Try to update the item to the database
            try
            {
                // Open a new connection to the database
                using (var connection = Connect())
                {
                    // Read all selects from the stored procedure
                    using(var read = await connection.QueryMultipleAsync(
                        "UpdateItem", new { ItemID = item.ItemID,
                                            Name   = item.Name,
                                            Stock  = item.Stock,
                                            Price  = item.Price,
                                            Image  = item.Image,
                                            Description = item.Description
                        }, commandType: CommandType.StoredProcedure)) {
                        res.Result = read.Read<QueryResults>().First();
                        res.Item   = read.Read<Item>().First();
                    }
                }
            }
            // If query failed on the API level
            catch
            {
                // Set new error status
                res.Result = QueryResults.APIError;
            }

            // Return the result
            return res;
        }

        #endregion

        // Functions for the order controller
        #region Order controller

        /// <summary>
        /// <see cref="IRepository.CreateOrder(Order)"/>
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<DBOrderResult> CreateOrder(PostOrder order)
        {
            // This can fail if for example on internet disconnect
            try
            {
                // Open a connection to the database
                using(var connection = Connect())
                {
                    // Create the order result
                    var orderRes = new DBOrderResult();

                    // Create a hashset
                    var set = new HashSet<int>();

                    // Check if all items in the order is available
                    for (int i = 0; i < order.Items.Count(); i++)
                    {
                        // Continue if the item id has been checked
                        if (set.Contains(order.Items[i])) continue;

                        // Check if the item is available
                        var av = (await connection.QueryAsync<bool>("IsItemsAvailable", new
                        {
                            ItemID = order.Items[i],
                            Amount = order.Items.Select(i => i).Count()
                        }, commandType: CommandType.StoredProcedure)).First();

                        // If the seller does not have enough of this item
                        if (av) return new DBOrderResult() { Result = QueryResults.Invalid }; // Return new invalid result

                        // Add the item to the 'checked list'
                        set.Add(order.Items[i]);
                    }

                    // Read all selects from the query
                    using (var reader = await connection.QueryMultipleAsync("CreateOrder", 
                          new { SellerID = order.SellerID },commandType: CommandType.StoredProcedure))
                    {
                        orderRes.Result = reader.Read<QueryResults>().First();
                        orderRes.Order  = reader.Read<Order>().First();
                        orderRes.Order.Items = new System.Collections.Generic.List<Item>();
                    }

                    // If order was created
                    if (orderRes.Result == QueryResults.Successful)
                    {
                        // Loop through all items in the order
                        for (int i = 0; i < order.Items.Count(); i++)
                        {
                            // Create item result
                            var itemRes = new DBItemResult();

                            // Read all selects from the query
                            using (var read = await connection.QueryMultipleAsync("AddToOrder",
                                    new { OrderID = orderRes.Order.OrderID, ItemID = order.Items[i] },
                                    commandType: CommandType.StoredProcedure)) {
                                // Read all selects
                                itemRes.Result = read.Read<QueryResults>().First();
                                itemRes.Item = read.Read<Item>().First();
                            }

                            // Continue if the item could be added
                            if (itemRes.Result == QueryResults.Successful)
                            {
                                // Add the item to the order object
                                orderRes.Order.Items.Add(itemRes.Item);
                                // Continue
                                continue;
                            }
                            // SQL side error or item did not belong to the seller marked on the order
                            else
                            {
                                // Set status code
                                orderRes.Result = itemRes.Result;
                                // Break out of the loop
                                break;
                            }
                        }

                        // If errors occurred but the order was created anyway
                        if(orderRes.Result != QueryResults.Successful)
                        {
                            // delete the order
                            var delRes = await DeleteOrder(orderRes.Order.OrderID);
                        }

                        // Return the order id when all items hace been added
                        return orderRes;
                    }
                    // Else if the order could not be created
                    else throw new Exception();
                }
            }
            // If request failed
            catch
            {
                // Return API error
                return new DBOrderResult() { Order = null, Result = QueryResults.APIError };
            }
        }

        /// <summary>
        /// <see cref="IRepository.GetOrder(int)"/>
        /// </summary>
        /// <param name="orderID">The order identifier</param>
        /// <returns></returns>
        public async Task<DBOrderResult> GetOrder(int orderID)
        {
            var orderRes = new DBOrderResult() { Order = null };
            // Open a new database connection
            using (var connection = Connect())
            {
                // Read all selects from the query
                using (var reader = await connection.QueryMultipleAsync("GetOrder",
                      new { OrderID = orderID }, commandType: CommandType.StoredProcedure))
                {
                    orderRes.Result      = reader.Read<QueryResults>().First();
                    orderRes.Order       = reader.Read<Order>().First();
                    orderRes.Order.Items = reader.Read<Item>().ToList();
                }
            }

            // Return the result
            return orderRes;
        }

        /// <summary>
        /// <see cref="IRepository.DeleteOrder(int)"
        /// </summary>
        /// <param name="orderID">The order identifier</param>
        /// <returns></returns>
        public async Task<DBResult> DeleteOrder(int orderID)
        {
            // Open a database connection
            using (var connection = Connect())
            {
                // Delete the item and fetch the result code
                var res = (await connection.QueryAsync<DBResult>("DeleteOrder", new { OrderID = orderID },
                    commandType: CommandType.StoredProcedure)).First();
                // Return the result
                return res;
            }
        }

        #endregion

    }
}
