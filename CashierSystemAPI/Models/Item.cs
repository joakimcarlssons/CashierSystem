/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Model for an item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the seller identifier.
        /// </summary>
        public int SellerID { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        // Nullable properties
#nullable enable

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public float? Price { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        public int? Stock { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }

#nullable disable

    }
}
