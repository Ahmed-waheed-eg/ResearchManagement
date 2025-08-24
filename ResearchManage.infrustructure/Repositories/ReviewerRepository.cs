using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;

namespace ResearchManage.Infrustructure.Repositories
{
    public class ReviewerRepository(ApplicationDBContext _DbContext) : GenericRepo<Reviewer>(_DbContext), IReviwerRepository
    {
    }
}
