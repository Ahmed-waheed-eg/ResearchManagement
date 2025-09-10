using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Helpers;
using ResearchManage.Services.Abstarcts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResearchManage.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public AuthenticationService(UserManager<User> userManager, JwtSettings jwtSettings)
        {

            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        #endregion

        public Task<string> GetJWTTokenAsync(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("UserName",user.UserName),
                new Claim("Email",user.Email),
                new Claim("phoneNumber",user.PhoneNumber)
            };
            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.accessTokenExpireDateInMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(accessToken);

        }
    }
}
