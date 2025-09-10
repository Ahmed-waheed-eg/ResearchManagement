using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;

namespace ResearchManage.Infrustructure.Repositories
{
    public class RefreshTokenRepository(ApplicationDBContext _dbcontext) : GenericRepo<UserRefreshToken>(_dbcontext), IRefreshTokenRepository
    {
    }
}
