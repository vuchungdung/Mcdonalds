using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        [Route("insert")]
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
        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> List(SearchViewModel viewModel)
        {
            var query = await _db.Categories.ToListAsync();

            if (!string.IsNullOrEmpty(viewModel.Keyword))
            {
                query = query.Where(s=>s.Name.ToLower().Contains(viewModel.Keyword.ToLower())).ToList();
            }

            PageResultViewModel<CategoryViewModel> result = new PageResultViewModel<CategoryViewModel>()
            {
                Total = query.Count(),
                Records = query
                        .Skip((viewModel.Page-1)*viewModel.Size)
                        .Take(viewModel.Size)
                        .Select(s=> new CategoryViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Description = s.Description,
                            ParentId = s.ParentId
                        })
                        .ToList()
            };

            return Ok(result);
        }
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Category model = await _db.Categories.FindAsync(id);
                _db.Categories.Remove(model);
                await _db.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(CategoryViewModel viewModel)
        {
            try
            {
                Category model = await _db.Categories.FindAsync(viewModel.Id);
                model.Name = viewModel.Name;
                model.Description = viewModel.Description;
                model.ParentId = viewModel.ParentId;
                _db.Categories.Update(model);
                await _db.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        [Route("item/{id}")]
        public async Task<IActionResult> Item(int id)
        {
            try
            {
                Category category = await _db.Categories.FindAsync(id);
                return Ok(category);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Dropdown()
        {
            var results = await _db.Categories.ToListAsync();
            return Ok(results);
        }
    }
}
