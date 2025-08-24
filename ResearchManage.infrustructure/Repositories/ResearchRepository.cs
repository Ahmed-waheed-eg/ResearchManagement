using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;

namespace ResearchManage.Infrustructure.Repositories
{
    public class ResearchRepository(ApplicationDBContext _dbcontext):GenericRepo<Research>(_dbcontext), IResearchRepository
    {
    }
}
