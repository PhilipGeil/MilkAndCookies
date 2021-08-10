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
    public class CookieController : Controller
    {
        [HttpGet]
        public string SetCookie(string favorite)
        {
            CookieOptions co = new CookieOptions();
            co.MaxAge = TimeSpan.FromMinutes(5);
            Response.Cookies.Append("favoriteMilkshake", favorite, co);
            return favorite;
        }

        [HttpGet]
        [Route("[action]")]
        public string GetFromCookie()
        {
            string cookie = Request.Cookies["favoriteMilkshake"];

            CookieOptions co = new CookieOptions();
            co.MaxAge = TimeSpan.FromSeconds(0);
            Response.Cookies.Append("favoriteMilkshake", "cookie", co);
            return cookie;
        }
    }
}
