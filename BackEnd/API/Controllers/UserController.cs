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
    public class UserController : ControllerBase
    {
        private readonly MCDbContext _db;
        public UserController(MCDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            try
            {
                User user = new User();
                user.UserName = viewModel.UserName;
                user.Password = viewModel.Password;
                user.Email = viewModel.Email;
                user.Phone = viewModel.Phone;
                user.Image = viewModel.Image;
                user.RoleId = viewModel.RoleId;
                user.FullName = viewModel.FullName;
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return Ok(user.FullName);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Update(UserViewModel viewModel)
        {
            try
            {
                User user = await _db.Users.FindAsync(viewModel.Id);
                if(user == null)
                {
                    return BadRequest();
                }
                user.UserName = viewModel.UserName;
                user.Password = viewModel.Password;
                user.Email = viewModel.Email;
                user.Phone = viewModel.Phone;
                user.Image = viewModel.Image;
                user.RoleId = viewModel.RoleId;
                user.FullName = viewModel.FullName;

                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                return Ok(user.FullName);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Item(int id)
        {
            try
            {
                User user = await _db.Users.FindAsync(id);
                
                if(user == null)
                {
                    return BadRequest();
                }

                UserViewModel viewModel = new UserViewModel();
                viewModel.Id = user.Id;
                viewModel.UserName = user.UserName;
                viewModel.Password = user.Password;
                viewModel.FullName = user.FullName;
                viewModel.Image = user.Image;
                viewModel.RoleId = user.RoleId;
                viewModel.Email = user.Email;
                viewModel.Phone = user.Phone;

                return Ok(viewModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IActionResult> List(SearchViewModel viewModel)
        {
            var query = await _db.Users.ToListAsync();

            if (!string.IsNullOrEmpty(viewModel.Keyword))
            {
                query = query.Where(s => s.FullName.ToLower().Contains(viewModel.Keyword.ToLower())).ToList();
            }

            PageResultViewModel<UserViewModel> result = new PageResultViewModel<UserViewModel>()
            {
                Total = query.Count(),
                Records = query
                        .Take((viewModel.Page - 1) * viewModel.Size)
                        .Take(viewModel.Size)
                        .Select(s => new UserViewModel()
                        {
                            Id = s.Id,
                            FullName = s.FullName,
                            Image = s.Image,
                            RoleId = s.RoleId,
                            Email = s.Email,
                            Phone = s.Phone,
                            UserName = s.UserName
                        })
                        .ToList()
            };

            return Ok(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                User user = await _db.Users.FindAsync(id);
                if(user == null)
                {
                    return BadRequest();
                }
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return Ok(user.FullName);
            }
            catch
            {
                throw;
            }
        }
    }
}
