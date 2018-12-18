using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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