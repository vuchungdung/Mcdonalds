using API.Areas.Admin.Models;
using API.Entities;
using API.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Areas.Admin.Services
{
    public interface IUserService
    {
        Task<AuthenViewModel> Authenticate(LoginViewModel model);
        Task<bool> Create(UserViewModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(UserViewModel model);
        Task<UserViewModel> Item(int id);
    }
    public class UserService : IUserService
    {
        private MCDbContext _context;
        private readonly AppSetting _appSetting;

        public UserService(MCDbContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }

        public async Task<AuthenViewModel> Authenticate(LoginViewModel model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName && x.Password == PasswordSecurity.GetHashedPassword(model.Password)).ConfigureAwait(false);

                if (user == null) return null;

                var token = generateJwtToken(user);

                return new AuthenViewModel(user.Id, user.FullName, user.UserName, user.Image, token);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Create(UserViewModel model)
        {
            try
            {
                var user = new User();
                user.FullName = model.FullName;
                user.UserName = model.UserName;
                user.Password = PasswordSecurity.GetHashedPassword(model.Password);
                user.Phone = model.Phone;
                user.Email = model.Email;
                user.Image = model.Image;
                user.RoleId = 1;
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if(user == null)
                {
                    return false;
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
                
            }
            catch
            {
                throw;
            }
        }

        public Task<UserViewModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserViewModel model)
        {
            throw new NotImplementedException();
        }
        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName.ToString()),
                    new Claim(ClaimTypes.UserData, user.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
