using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;

namespace ResearchManage.Infrustructure.Repositories
{
    public  class CommentRepository(ApplicationDBContext _DbContext): GenericRepo<Comment>(_DbContext),ICommentRepository
    {
    }
}
