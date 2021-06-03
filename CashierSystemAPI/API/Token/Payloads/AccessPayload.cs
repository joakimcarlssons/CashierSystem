/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using JWTLib;
    using System;

    /// <summary>
    /// A payload that holds the user's id (gets returned when user created or 'signing in')
    /// </summary>
    public class AccessPayload
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the phone number for this user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets the expiration date of the token.
        /// </summary>
        public long exp => NumericDate.Convert(DateTime.Now.AddDays(1));
    }
}
