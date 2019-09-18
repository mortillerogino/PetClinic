using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetClinic.Core.Models.Identity;
using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Security
{
    public class UserTokenHandler
    {
        private readonly ApplicationUser _user;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<AppSettings> _appSettings;

        public UserTokenHandler(ApplicationUser user, UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings)
        {
            _user = user;
            _userManager = userManager;
            _appSettings = appSettings;
        }

        private async Task<IList<Claim>> GetUserClaims()
        {
            return await _userManager.GetClaimsAsync(_user);
        }

        private SecurityTokenDescriptor CreateTokenDescriptor(IList<Claim> userClaims)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }

        private JwtSecurityTokenHandler CreateTokenHandler()
        {
            return new JwtSecurityTokenHandler();
        }

        private SecurityToken CreateSecurityToken(SecurityTokenDescriptor tokenDescriptor, JwtSecurityTokenHandler tokenHandler)
        {
            return tokenHandler.CreateToken(tokenDescriptor);
        }

        private string GetTokenString(JwtSecurityTokenHandler tokenHandler, SecurityToken securityToken)
        {
            return tokenHandler.WriteToken(securityToken);
        }

        public async Task<string> CreateUserToken()
        {
            var userClaims = await GetUserClaims();
            var tokenDescriptor = CreateTokenDescriptor(userClaims);
            var tokenHandler = CreateTokenHandler();
            var securityToken = CreateSecurityToken(tokenDescriptor, tokenHandler);
            return GetTokenString(tokenHandler, securityToken);
        }

    }
}
