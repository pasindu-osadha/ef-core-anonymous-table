using ef_core_anonymous_table.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ef_core_anonymous_table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult getAllProducts()
        {
            var a = _context.Products.ToList();
            return Ok(a);
        }
    }
}
