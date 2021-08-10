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
        IAccountRepository _accountRepository;
        IConfiguration _configuration;
        public AccountService(IAccountRepository accountRepository, IConfiguration configuration) :base(accountRepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
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
                    var secretKey = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);
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
    }
}
