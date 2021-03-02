/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Collections.Generic;

    /// <summary>
    /// Defines the requred body for when posing an 'order create' request
    /// </summary>
    public class PostOrder
    {
        /// <summary>
        /// The seller of all the items
        /// </summary>
        public int SellerID { get; set; }

        /// <summary>
        /// All items in the order
        /// </summary>
        public List<int> Items { get; set; }
    }
}
