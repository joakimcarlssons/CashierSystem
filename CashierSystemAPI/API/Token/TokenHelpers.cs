﻿/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using JWTLib;

    /// <summary>
    /// Contains token helpers
    /// </summary>
    public static class TokenHelpers
    {
        /// <summary>
        /// Formats the authorization header.
        /// </summary>
        /// <param name="authorization">The authorization.</param>
        /// <returns></returns>
        public static JWSToken<JWSHeader, AccessPayload> FormatAuthorizationHeader(string authorization)
        {
            // If the token is missing
            if (authorization == null) return null;

            // Check how this token starts...

            // If it starts with 'bearer'...
            if (authorization.StartsWith("Bearer "))
                authorization = authorization.Substring(7);
            // Else format normally...
            else
            {
                // Try to format the token
                try
                {
                    authorization = authorization.Substring(1, authorization.Length - 2);
                }
                // If formating failed... return null response
                catch { return null; }
            }

            // Convert jwt into a token object
            return JWSTokenHandler.ToToken<JWSToken<JWSHeader, AccessPayload>>(authorization);
        }

        /// <summary>
        /// Creates the user token. (This removes the need for having the key seperated in the api)
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static JWSToken<JWSHeader, AccessPayload> CreateAccessToken(User user)
        {
            // Create the JWT token
            var token =
                JWSTokenBuilder.BuildToken<JWSToken<JWSHeader, AccessPayload>>(JWSAlgorithms.HS256, new AccessPayload() 
                { 
                    UserID = user.UserID, 
                    PhoneNumber = user.PhoneNumber 
                }, "secret");

            // Return the token
            return token;
        }

        /// <summary>
        /// Verifies the token. (This removes the need for having the key seperated in the api)
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public static VerifyResults VerifyToken(IJWSToken token)
        {
            // Validate the JWT
            var verify = JWSTokenHandler.Verify(token, "secret");
            // Return the result
            return verify;
        }
    }
}
