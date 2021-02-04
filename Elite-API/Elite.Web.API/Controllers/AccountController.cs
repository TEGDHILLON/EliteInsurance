using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Elite.Web.API.Business.Managers;
using Elite.Web.API.Others.DTOs;

namespace Elite.Web.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountManager _accountManager;
        public AccountController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost("register")]
        public IActionResult Register(AccountDTO register)
        {
            try
            {
                var result = _accountManager.Register(register);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                var result = _accountManager.Login(login);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
