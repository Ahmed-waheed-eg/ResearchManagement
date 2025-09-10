using ResearchManage.Domain.Entities.Identity;

namespace ResearchManage.Services.Abstarcts
{
    public interface IAuthenticationService
    {
        public Task<string> GetJWTTokenAsync(User user);
    }
}
