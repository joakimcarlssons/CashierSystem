/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Collections.Generic;

    /// <summary>
    /// Defines a order
    /// </summary>
    public class Order 
    {
        /// <summary>
        /// The order ID (This will be returned by the database when the order is created)
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// The seller of all the items
        /// </summary>
        public int SellerID { get; set; }

        /// <summary>
        /// All items in the order
        /// </summary>
        public List<Item> Items { get; set; }
    }
}