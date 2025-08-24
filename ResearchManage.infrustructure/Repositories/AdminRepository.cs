using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;
namespace ResearchManage.Infrustructure.Repositories
{
    public class AdminRepository(ApplicationDBContext _dbcontext):GenericRepo<Admin>(_dbcontext),IAdminRepository
    {
    }
}
