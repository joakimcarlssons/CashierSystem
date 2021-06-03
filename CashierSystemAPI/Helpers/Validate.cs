/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains validate functions for properties
    /// </summary>
    public static class Validate
    {
        #region Public functions
        
        /// <summary>
        /// Validate a phone number
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public static bool PhoneNumber(string phoneNumber)
        {
            // Check if the input string is a match for a swedish phone number
            var isMatch = Regex.IsMatch(phoneNumber, RegexPatterns.SwedenPhoneNumber);

            // Phone number is valid
            return isMatch;
        }

        #endregion

    }
}
