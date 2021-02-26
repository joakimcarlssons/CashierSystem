/// <summary>
/// Root namespaces
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller for all user requests
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<User> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public UserController(ILogger<User> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Creates a new <see cref="User"/>
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/user/create")]
        public async Task<IActionResult> Create([FromBody] LoginBody login)
        {
            // Should only fail if an internal server error occurred
            try
            {
                // This list will contain errors
                bool errors = false;

                // Check that the PIN is 4 digits long...
                if (Math.Floor(Math.Log10(login.PIN)) + 1 != 4)
                    // Add error message
                    errors = true;
                if (login.PhoneNumber.Length != 10 || !ulong.TryParse(login.PhoneNumber, out _))
                    // Add error message
                    errors = true;

                // If no errors exist...
                if (!errors)
                {
                    // Create the user
                    var query = await Container.Repository.CreateUser(login.PhoneNumber, login.PIN);

                    // If user could be created
                    if (query.Result == QueryResults.Successful)
                    {
                        // Create the user object
                        var u = new User()
                        {
                            UserID = query.UserID,
                            PhoneNumber = login.PhoneNumber
                        };

                        // Return the JWT token to the client
                        return Ok(new AuthResponse(TokenHelpers.CreateAccessToken(u).JWT, u));
                    }
                    else
                        // Return the JWT token to the client
                        return BadRequest(new ErrorResponse(400, "Could not crete user"));

                }
                // If errors exist...
                return BadRequest(new ErrorResponse(400, "Could not crete user"));
            }
            // Internal error
            catch { return StatusCode(500, new ErrorResponse(500, "Internal server error")); }

        }

        /// <summary>
        /// Gets the get user.
        /// </summary>
        /// <param name="authorization">The authorization.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/user/login")]
        public async Task<IActionResult> Login([FromBody] LoginBody login)
        {
            // Should only fail if an internal server error occurred
            try
            {
                // Try to login the user
                var query = await Container.Repository.LoginUser(login.PhoneNumber, login.PIN);

                // If the login was successful
                if(query.Result == QueryResults.Successful)
                {
                    // Create the user object
                    var u = new User()
                    {
                        UserID = query.UserID,
                        PhoneNumber = login.PhoneNumber
                    };

                    // Return a bad request
                    return Ok(new AuthResponse(TokenHelpers.CreateAccessToken(u).JWT, u));
                }
                // Else...
                else
                {
                    // Return unauthorized reponse with error message
                    return Unauthorized(new ErrorResponse(401, "Login failed"));
                }
            }
            // Return server error code
            catch { return StatusCode(500, new ErrorResponse(500, "Internal server error")); }
        }
    }
}
