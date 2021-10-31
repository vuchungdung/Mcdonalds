using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<IActionResult> Add(ProductViewModel viewModel)
        {
            try
            {
                Product product = new Product();
                product.Id = viewModel.Id;
                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.CategoryId = viewModel.CategoryId;
                product.Content = viewModel.Content;
                product.Price = viewModel.Price;
                product.Range = viewModel.Range;
                product.OriginalPrice = viewModel.OriginalPrice;
                product.CreatedDate = viewModel.CreatedDate;
                product.Status = viewModel.Status;
                product.Image = viewModel.Image;

                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return Ok(viewModel.Name);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Update(ProductViewModel viewModel)
        {
            try
            {
                Product product = await _db.Products.FindAsync(viewModel.Id);

                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.CategoryId = viewModel.CategoryId;
                product.Content = viewModel.Content;
                product.Price = viewModel.Price;
                product.Range = viewModel.Range;
                product.OriginalPrice = viewModel.OriginalPrice;
                product.CreatedDate = viewModel.CreatedDate;
                product.Status = viewModel.Status;
                product.Image = viewModel.Image;

                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return Ok(viewModel.Name);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> List(SearchViewModel viewModel)
        {
            var query = await _db.Products.ToListAsync();

            if (!string.IsNullOrEmpty(viewModel.Keyword))
            {
                query = query.Where(s => s.Name.ToLower().Contains(viewModel.Keyword.ToLower())).ToList();
            }

            PageResultViewModel<ProductViewModel> result = new PageResultViewModel<ProductViewModel>()
            {
                Total = query.Count(),
                Records = query
                        .Take((viewModel.Page - 1) * viewModel.Size)
                        .Take(viewModel.Size)
                        .Select(s => new ProductViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Description = s.Description,
                            Image = s.Image,
                            Price = s.Price,
                            OriginalPrice = s.OriginalPrice
                        })
                        .ToList()
            };

            return Ok(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product product = await _db.Products.FindAsync(id);
                if (product == null)
                {
                    return BadRequest();
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return Ok(product.Name);
            }
            catch
            {
                throw;
            }
        }
    }
}
