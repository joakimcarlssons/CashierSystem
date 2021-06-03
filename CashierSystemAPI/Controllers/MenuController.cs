/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Threading.Tasks;
    using JWTLib;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class MenuController : Controller
    {
        /// <summary>
        /// Returns the menu bound to the provided user id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/menu/{id?}")]
        public async Task<IActionResult> Get(int? id, [FromHeader] string authorization)
        {
            // This should only fail an internal error occurred
            try
            {
                // Format the authorization header
                var token = TokenHelpers.FormatAuthorizationHeader(authorization);

                // If no token is provided but an id was provided
                if (id != null)
                {
                    // Get the items
                    var res = await Container.Repository.GetMenu((int)id);

                    // Return the items
                    return Ok(new MenuResponse($"User {id}'s items", res));
                }
                // If token was provided and no id was provided
                else if (token != null && id == null)
                {
                    // If the JWT is valid...
                    if (TokenHelpers.VerifyToken(token) == VerifyResults.Valid)
                    {
                        // Get the users items
                        var res = await Container.Repository.GetMenu(token.Payload.UserID);

                        // Return the items
                        return Ok(new MenuResponse("Your items", res));
                    }
                    // Else...
                    else return Unauthorized( // Return unaturhorized result
                        new ErrorResponse(401, "Unauthorized"));
                }
                else
                    // Return a bad request
                    return BadRequest(new ErrorResponse(400, "bad request"));
            }
            // Return response that tells there was a server error
            catch { return StatusCode(500, new ErrorResponse(500, "Internal server error")); }
        }
    }
}
