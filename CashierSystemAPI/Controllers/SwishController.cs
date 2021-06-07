namespace CashierSystemAPI
{
    // Required namespaces
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Controller for swish requests
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    public class SwishController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Swish> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwishController"/> class.
        /// </summary>
        public SwishController(ILogger<Swish> logger)
        {
            // Set the logger
            this._logger = logger;
        }

        [HttpPost]
        [Route("/Swish/QR")]
        public async Task<IActionResult> GetQR([FromBody] PostSwish _swish, [FromHeader] string authorization)
        {
            // Should only fail on interna server error
            try
            {
                // Format the authorization header
                var token = TokenHelpers.FormatAuthorizationHeader(authorization);
                // If validation failed
                if (token == null) return Unauthorized(new DynamicResponse("Unauthorized"));

                // If the token is valid
                if(TokenHelpers.VerifyToken(token) == JWTLib.VerifyResults.Valid)
                {
                    // Create a new http client that will be used to call the swish API
                    using(var client = new HttpClient())
                    {
                        // Create the request uri
                        client.BaseAddress = new Uri("https://cors-anywhere.herokuapp.com/https://mpc.getswish.net/qrg-swish/api/v1/");
                        // Add the requred request header
                        client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                        // Create the swish object
                        var swish = new Swish()
                        {
                            Format = "svg",
                            Payee = new Payee()
                            {
                                Value = token.Payload.PhoneNumber,
                                Editable = false
                            },
                            Amount = new Amount()
                            {
                                Value = _swish.Price.ToString(),
                                Editable = false
                            }
                        };
                        // Create json from the new swish object
                        var swishJson = JsonConvert.SerializeObject(swish);
                        // Create request data
                        var data = new StringContent(swishJson, Encoding.UTF8, "application/json");
                        // Make API request
                        var res = await client.PostAsync("prefilled", data);
                        // Read the request result
                        string reqRes = res.Content.ReadAsStringAsync().Result;

                        // Return formated result
                        return Ok(new SwishResponse(reqRes, swish));
                    }
                }
                // Else if the token is not valid...
                else
                    return Unauthorized( // Return unaturhorized result
                        new ErrorResponse(401, "Unauthorized"));
            }
            // If internal server error occurred
            catch
            {
                // Return response that tells there was a server error
                return StatusCode(500, new ErrorResponse(500, "Internal server error"));
            }
        }
    }
}
