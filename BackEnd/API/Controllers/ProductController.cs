using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MCDbContext _db;

        public ProductController(MCDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Add(Product product)
        {
            return Ok();
        }
    }
}
