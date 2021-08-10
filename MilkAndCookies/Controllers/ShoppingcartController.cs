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
    public class ShoppingcartController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get(string name, double price)
        {
            Product p = new Product(name, price);
            List<Product> products;
            if (HttpContext.Session.GetString("cart") == null)
            {
                products = new List<Product>();
            }
            else
            {
                products = HttpContext.Session.GetObjectFromJson<List<Product>>("cart");
            }
            products.Add(p);
            HttpContext.Session.SetObjectAsJson("cart", products);
            return products;
        }
    }
}
