using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Service
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        #region Field
        IAccountRepository _accountRepository;
        IConfiguration _configuration;
        #endregion

        #region Constructor
        public AccountService(IAccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
        }
        #endregion

        #region Methods
        public override int Insert(Account account)
        {
            // Tạo chuỗi muối để tiến hành mã hóa mật khẩu
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            // Thực hiện mã hóa mật khẩu trước khi lưu
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password, salt);
            return base.Insert(account);
        }

        public ResponseLogin Login(string userName, string password)
        {
            var account = _accountRepository.GetAccountdByUserName(userName);
            if (account != null)
            {
                var userPassword = _accountRepository.GetPasswordByUserName(userName);
                if (BCrypt.Net.BCrypt.Verify(password, userPassword))
                {
                    // Tạo token 
                    var tokenHandler = new JwtSecurityTokenHandler();
                    // Tạo khóa bí mật
                    var secretKey = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);
                    // Khai báo đặc điểm của Token
                    var tokenDecriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, account.AccountId.ToString())
                }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDecriptor);
                    return new ResponseLogin()
                    {
                        Token = tokenHandler.WriteToken(token),
                        AccountInfo = account
                    };
                }
            }
            return null;
        }
        #endregion

    }
}
