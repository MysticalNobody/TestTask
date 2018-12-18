using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/SendMessage")]
    [Produces("application/json")]
    public class SendMessageController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Message data)
        {
            if (data == null)
            {
                return BadRequest("Params data is null");
            }
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("https://api.pushover.net/1/messages.json", data.ToFormUrl());
                if (response.IsSuccessStatusCode)
                {
                    return Ok("Success");
                }
                else
                {
                    return BadRequest("Cannot create push notification");

                }
            }
        }
    }
}