using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace ResearchManage.Services.Abstarcts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthTokenResponse> GetJWTTokenAsync(User user);
        JwtSecurityToken ReadJwtToken(string accessToken);
        Task<string>? ValidateBeforeRenewTokenAsync(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        Task<UserRefreshToken> GetUserFullRefreshTokenObjByRefreshToken(string refreshToken);
        Task<JwtAuthTokenResponse> CreateNewAccessTokenByRefreshToken(string accessToken, UserRefreshToken userRefreshToken);
        Task<string>? ValidateAccessTokenAsync(string accessToken);
    }
}
