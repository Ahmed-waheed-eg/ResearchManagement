using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Services.Abstarcts
{
    public interface IResearchServices
    {
        Task<Research> GetResearchByIdWithIncludeAsync(int  id);
        public IQueryable<Research> FilterResearchQueryble(enOrderingResearchEnum OrderBy, string search);
        public IQueryable<Research> GetResearchByQueryable(Expression<Func<Research, bool>> predicate);

    }
}
