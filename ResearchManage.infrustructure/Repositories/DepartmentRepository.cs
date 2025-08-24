using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;


namespace ResearchManage.Infrustructure.Repositories
{
    public class DepartmentRepository(ApplicationDBContext _dBContext):GenericRepo<Department>(_dBContext),IDepartmentRepository
    {
    }
}
