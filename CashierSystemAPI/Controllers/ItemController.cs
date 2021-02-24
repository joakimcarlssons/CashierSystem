/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required nemespaces
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using JWTLib;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller for Item requests
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("[Controller]")]
    public class ItemController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Item> Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ItemController(ILogger<Item> logger)
        {
            // Set the logger
            this.Logger = logger;
        }

        /// <summary>
        /// Adds the item(s) to the user in the auth token
        /// </summary>
        /// <param name="item">The item in JSON.</param>
        /// <param name="authorization">The authorization token.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Item item, [FromHeader] string authorization)
        {
            // This should only fail if there was an internal server error
            try
            {
                // Format the authorization header
                var token = TokenHelpers.FormatAuthorizationHeader(authorization);
                // If validation failed
                if (token == null) return Unauthorized(new APIResponse("Unauthorized"));
                // Else...
                else
                {
                    // If the JWT is valid...
                    if (TokenHelpers.VerifyToken(token) == VerifyResults.Valid) 
                    {
                        // Set the user id on the item
                        item.SellerID = token.Payload.UserID;
                        
                        // Add the item and get the result
                        var res = await Container.Repository.AddItem(item);

                        // If the item was added successfuly
                        if(res.Result == QueryResults.Successful)
                        {
                            // The item was added so return OK response
                            return Ok(new APIResponse("Item(s) added"));
                        }
                        // Else...
                        else
                        {
                            // Return a bad request
                            return BadRequest(new APIResponse(new string[] { "Bad request", "Query result: " + res.Result.ToString() }));
                        }

                    }
                    // Else...
                    else { return Unauthorized(new APIResponse(new string[] { "Unauthorized" })); } // Return 'JWT is invalid' response

                }
            }
            // Return response that tells there was a server error
            catch { return StatusCode(500, new APIResponse("Error")); }

        }

        /// <summary>
        /// Removes the item compleatly from the database
        /// </summary>
        /// <param name="id">The id of the item(s).</param>
        /// <param name="authorization">The authorization token.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/item/{id}")]
        public async Task<IActionResult> Delete(int id, [FromHeader] string authorization)
        {
            // This should only fail if there was an internal server error
            try
            {
                // Format the authorization header
                var token = TokenHelpers.FormatAuthorizationHeader(authorization);
                // If validation failed
                if (token == null) return Unauthorized(new APIResponse("Unauthorized"));
                // Else...
                else
                {
                    // If the JWT is valid...
                    if (TokenHelpers.VerifyToken(token) == VerifyResults.Valid)
                    {
                        // Delete the item and get the result
                        var res = await Container.Repository.DeleteItem(id);

                        // If the item was removed successfuly
                        if(res.Result == QueryResults.Successful)
                        {
                            // Send back Ok response
                            return Ok(new APIResponse("Item(s) removed"));
                        }
                        // Else...
                        else
                        {
                            // Return a bad request
                            return BadRequest(new APIResponse(new string[] { "Bad request", "Query result: " + res.Result.ToString() }));
                        }
                    }
                    // Else...
                    else { return Unauthorized(new APIResponse(new string[] { "Unauthorized" })); } // Return 'JWT is invalid' response

                }
            }
            // Return response that tells there was a server error
            catch { return StatusCode(500, new APIResponse("Error")); }

        }

        /// <summary>
        /// Patcher an existing item
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authorization">The authorization.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("/item/{id}")]
        public async Task<IActionResult> Patch(int id, [FromHeader] string authorization, 
                                                       [FromBody]   Item item)
        {
            // This should only fail if there was an internal server error
            try
            {
                // Format the authorization header
                var token = TokenHelpers.FormatAuthorizationHeader(authorization);
                // If validation failed
                if (token == null) return Unauthorized(new APIResponse("Unauthorized"));
                // Else...
                else
                {
                    // If the JWT is valid...
                    if (TokenHelpers.VerifyToken(token) == VerifyResults.Valid)
                    {
                        // Set the item id
                        item.ItemID = id;
                        // Update the item and get the result
                        var res = await Container.Repository.UpdateItem(item);

                        // If the item was updated successfuly
                        if(res.Result == QueryResults.Successful)
                        {
                            return Ok(new APIResponse("Item(s) updated"));
                        }
                        else
                        {
                            // Return a bad request
                            return BadRequest(new APIResponse(new string[] { "Bad request", "Query result: " + res.Result.ToString() }));
                        }

                    }
                    // Else...
                    else { return Unauthorized(new APIResponse(new string[] { "Unauthorized" })); } // Return 'JWT is invalid' response

                }
            }
            // Return response that tells there was a server error
            catch { return StatusCode(500, new APIResponse("Error")); }
        }
    }
}
