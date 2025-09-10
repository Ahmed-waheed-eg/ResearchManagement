using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Infrustructure.GenericBases;

namespace ResearchManage.Infrustructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepo<UserRefreshToken>
    {
    }
}
