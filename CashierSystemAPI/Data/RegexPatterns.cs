namespace CashierSystemAPI
{
    /// <summary>
    /// Contains regex patterns
    /// </summary>
    public static class RegexPatterns
    {
        /// <summary>
        /// Regex pattern for a swedish phone number
        /// </summary>
        public static string SwedenPhoneNumber { get => @"^(([+]46)\s*(7)|07)[02369]\s*(\d{4})\s*(\d{3})$"; }
    }
}
