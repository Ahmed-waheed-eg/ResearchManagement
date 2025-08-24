using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;

namespace ResearchManage.Infrustructure.Repositories
{
    public class SupervisorRepository(ApplicationDBContext _dbContext):GenericRepo<Supervisor>(_dbContext),ISupervisorRepository
    {
    }
}
