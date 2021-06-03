/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using Newtonsoft.Json;

    /// <summary>
    /// Swish object
    /// </summary>
    public class Swish
    {
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        [JsonProperty("payee")]
        public Payee Payee { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }

    /// <summary>
    /// Payee for a swish object
    /// </summary>
    public class Payee
    {
        /// <summary>
        /// Gets or sets the value. (Phonenumber)
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Payee"/> is editable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if editable; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("editable")]
        public bool Editable { get; set; }
    }

    /// <summary>
    /// Amount for a swich object
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// Gets or sets the value. (Price)
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Amount"/> is editable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if editable; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("editable")]
        public bool Editable { get; set; }
    }
}
