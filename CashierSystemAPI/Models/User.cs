﻿/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [MinLength(10)]
        public string PhoneNumber { get; set; }
    }
}
