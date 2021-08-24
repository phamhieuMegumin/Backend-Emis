using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        IAccountService _accountService;
        IAccountRepository _accountRepository;
        public AccountController(IAccountService accountService, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
        }

        /// <summary>
        /// Đăng nhập vào hệ thống
        /// </summary>
        /// <param name="accountInfo">Thông tin đăng nhập</param>
        /// <returns>
        /// Token - trả về Token cho người dùng
        /// AccountInfo - thông tin tài khoản của người dùng
        /// </returns>
        [HttpPost("login")]
        public IActionResult Login(LoginSchema accountInfo)
        {
           var token = _accountService.Login(accountInfo.UserName, accountInfo.Password);
            if(token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }

        /// <summary>
        /// Đăng ký tài khoản mới
        /// </summary>
        /// <param name="account">Thông tin tài khoản mới</param>
        /// <returns>
        /// 200 - Tài khoản tạo thành công
        /// 400 - Tài khoản tạo thất bại
        /// </returns>
        [HttpPost("register")]
        public IActionResult Register(Account account)
        {
            var rowEffects = _accountService.InsertWithoutAccount(account);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }

        [Authorize]
        [HttpGet("Authentication")]
        public IActionResult Authentication()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var accountId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var user = _accountRepository.GetById(Guid.Parse(accountId));
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }
    }
}
