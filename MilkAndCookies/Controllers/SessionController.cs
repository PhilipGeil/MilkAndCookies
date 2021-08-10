using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            HttpContext.Session.SetString("Test", "Philip Rules");
            return "Hello";
        } 

        [HttpGet]
        [Route("[action]")]
        public string GetSession()
        {
            return HttpContext.Session.GetString("Test");
        }
    }
}
