/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespaces
    using System.Threading.Tasks;
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
        [Route("/menu/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // This should only fail an internal error occurred
            try
            {
                // Get the items
                var res = await Container.Repository.GetMenu(id);

                // Return the items
                return Ok(new MenuResponse($"User {id}'s items", res));
            }
            // Return response that tells there was a server error
            catch { return StatusCode(500, new ErrorResponse(500, "Internal server error")); }
        }
    }
}
