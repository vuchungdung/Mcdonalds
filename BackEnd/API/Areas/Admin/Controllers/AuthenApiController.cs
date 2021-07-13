using API.Areas.Admin.Models;
using API.Areas.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Areas.Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class AuthenApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var result = await _userService.Authenticate(model);
            return Ok(result);
        }

        
    }
}
