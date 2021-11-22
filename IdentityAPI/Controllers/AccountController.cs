using Identity.Common;

using IdentityAPI.Helpers;
using IdentityAPI.Models;
using IdentityAPI.Services.Logic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IOptions<AuthOptions> _authOptions;

        public AccountController(IAccountService accountService, IOptions<AuthOptions> authOptions)
        {
            _accountService = accountService;
            _authOptions = authOptions;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var user = await _accountService.GetUserByLogin(request.Email, request.Password);
            if(user != null)
            {
                var token = JwtTokenHelper.GenerateJwt(user, _authOptions);
                return Json(new { auth_token = token });
            }

            return Unauthorized();
        }
    }
}
