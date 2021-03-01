/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    public class AuthResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public AuthResponseBody Response { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthResponse"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="user">The user.</param>
        public AuthResponse(string token, User user)
        {
            // Create the response body
            this.Response = new AuthResponseBody()
            {
                Token = token,
                User = user
            };
        }
    }
}
