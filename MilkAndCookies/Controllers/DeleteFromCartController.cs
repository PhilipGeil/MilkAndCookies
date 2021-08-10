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
    public class DeleteFromCartController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Delete(string name, double price)
        {
            Product p = new Product(name, price);
            // Create a list with products - to be the cart
            List<Product> products;

            // Check if the cart is empty
            if (HttpContext.Session.GetString("cart") == null)
            {
                // If empty we just return an empty list.
                return new List<Product>();
            } else
            {
                // Deserialize cart to object
                products = HttpContext.Session.GetObjectFromJson<List<Product>>("cart");
                products.Remove(p);
            }
            // Overwrite old session
            HttpContext.Session.SetObjectAsJson("cart", products);
            return products;
        }
    }
}
