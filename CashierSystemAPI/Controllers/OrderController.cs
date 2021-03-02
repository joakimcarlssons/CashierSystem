/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    using JWTLib;
    // Required namecpaces
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller for all order requests
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller 
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Order> Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class
        /// </summary>
        /// <param name="logger">The logger</param>
        public OrderController(ILogger<Order> logger) 
        {
            // Set the logger
            this.Logger = logger;
        }

        /// <summary>
        /// Creates a new <see cref="Order"/> and adds it to the database
        /// </summary>
        /// <param name="order"/>Ther order</param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostOrder order)
        {
            // Try to create the new order
            try 
            {
                // Add the order and get the response
                var result = await Container.Repository.CreateOrder(order);

                // If order could be created
                if(result.Result == QueryResults.Successful) 
                {
                    // Return Ok (200) response with the new order
                    return Ok(new OrderResponse("Order Created", result.Order));
                }
                // Else if order could not be created
                else
                {
                    // Return status code 400 (Bad request)
                    return BadRequest(
                        new ErrorResponse(400, "Order could not be created (" + result.Result.ToString() + ")"));
                }

            }
            // If failed...
            catch
            {
                // Return status code 500
                return StatusCode(500, new ErrorResponse(500, "Error"));
            }
        } 

        /// <summary>
        /// Delete an <see cref="Order"/> from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/Order/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // This can fail if internal error occurred
            try
            {
                // Delete the order
                var result = await Container.Repository.DeleteOrder(id);
                // If the order could be deleted
                if(result.Result == QueryResults.Successful)
                {
                    // Return ok response
                    return Ok(new DynamicResponse("Order deleted"));
                }
                else
                {
                    // Return ok response
                    return BadRequest(
                        new ErrorResponse(400, "Order could not be deleted (" + result.Result.ToString() +")"));
                }
            }
            catch
            {
                // Return 500 status code
                return StatusCode(500, new ErrorResponse(500, "Error"));
            }
        }

        /// <summary>
        /// Gets an <see cref="Order"/> from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Order/{id}")]
        public async Task<IActionResult> Get(int id, [FromHeader] string authorization)
        {
            // This should only fail if there was an internal server error
            try
            {
                // Format the authorization header
                var token = TokenHelpers.FormatAuthorizationHeader(authorization);
                // If validation failed
                if (token == null) return Unauthorized(new DynamicResponse("Unauthorized"));
                // Else...
                else
                {
                    // If the JWT is valid...
                    if (TokenHelpers.VerifyToken(token) == VerifyResults.Valid)
                    {
                        // Get the order
                        var res = await Container.Repository.GetOrder(id);

                        // If the item was removed successfuly
                        if (res.Result == QueryResults.Successful)
                        {
                            if (res.Order.SellerID.Equals(token.Payload.UserID))
                            {
                                // Send back Ok response
                                return Ok(new OrderResponse("Order fetched", res.Order));
                            }
                            else
                            {
                                // This is order is for another seller
                                return Unauthorized( // Return unaturhorized result
                                    new ErrorResponse(401, "Unauthorized"));
                            }
                        }
                        // Else...
                        else
                        {
                            // Return a bad request
                            return BadRequest(
                                new ErrorResponse(400, "Could not fetch order (" + res.Result.ToString() + ")"));
                        }
                    }
                    // Else...
                    else
                        return Unauthorized( // Return unaturhorized result
                            new ErrorResponse(401, "Unauthorized"));
                }
            }
            // Return response that tells there was a server error
            catch { return StatusCode(500, new ErrorResponse(500, "Error")); }
        }
    }
}