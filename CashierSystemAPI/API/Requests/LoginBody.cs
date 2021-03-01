/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    /// <summary>
    /// Body for login requests
    /// </summary>
    public class LoginBody
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the pin.
        /// </summary>
        public int PIN { get; set; }
    }
}
