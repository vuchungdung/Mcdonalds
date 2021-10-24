using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MCDbContext _db;

        public CategoryController(MCDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel viewModel)
        {
            try
            {
                Category category = new Category();
                category.Name = viewModel.Name;
                category.Description = viewModel.Description;
                category.ParentId = viewModel.ParentId;
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
                return Ok(viewModel);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> List(string categoryId)
        {

        }
    }
}
