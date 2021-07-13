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
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel model)
        {
            var result = await _userService.Create(model);
            return Ok(result);
        }
    }
}
