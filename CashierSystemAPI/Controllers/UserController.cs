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
        public async Task<IActionResult> Create([FromBody] User user)
        {
            // Should only fail if an internal server error occurred
            try
            {
                // This list will contain errors
                List<string> errors = new List<string>();

                // Check that the PIN is 4 digits long...
                if (Math.Floor(Math.Log10(user.PIN)) + 1 != 4)
                    // Add error message
                    errors.Add("PIN must be 4 digits long");
                if(user.PhoneNumber.Length != 10 || !ulong.TryParse(user.PhoneNumber, out _))
                    // Add error message
                    errors.Add("Invalid phone number");

                // If no errors exist...
                if (errors.Count == 0)
                {
                    // Create the user
                    var query = await Container.Repository.CreateUser(user);

                    // If user could be created
                    if (query.Result == QueryResults.Successful)
                    {
                        // Return the JWT token to the client
                        return Ok(new APIResponse(TokenHelpers.CreateAccessToken(user).JWT));
                    }
                    else
                        // Return the JWT token to the client
                        return BadRequest(new APIResponse(new string[] { "Could not create user", 
                                                                         "Query result: " + query.Result.ToString() }));

                }
                // If errors exist...
                else return BadRequest(new APIResponse(errors)); // Return all errors as the response
            }
            // Internal error
            catch { return StatusCode(500, new APIResponse("Error")); }
        }

        /// <summary>
        /// Gets the get user.
        /// </summary>
        /// <param name="authorization">The authorization.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/user/login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            // Should only fail if an internal server error occurred
            try
            {
                // Try to login the user
                var query = await Container.Repository.LoginUser(user);

                // If the login was successful
                if(query.Result == QueryResults.Successful)
                {
                    // Set the userID that was returned from the database
                    user.UserID = (int)query.UserID;
                    // Return the JWT token to the client
                    return Ok(new APIResponse(TokenHelpers.CreateAccessToken(user).JWT));
                }
                // Else...
                else
                {
                    // Return unauthorized reponse with error message
                    return Unauthorized(new APIResponse(new string[] { "Login failed" }));
                }
            }
            // Return server error code
            catch { return StatusCode(500, new APIResponse("Error")); }
        }
    }
}
