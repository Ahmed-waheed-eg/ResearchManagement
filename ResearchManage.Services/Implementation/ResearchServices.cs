using Microsoft.EntityFrameworkCore;
using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Helpers;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Services.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Services.Implementation
{
    public class ResearchServices(IResearchRepository _researchRepository) : IResearchServices
    {
        public IQueryable<Research> FilterResearchQueryble(enOrderingResearchEnum OrderBy, string search)
        {
            var queryable=_researchRepository.GetTableAsTracking()
                .Include(r=>r.scholar)
                .Include(r=>r.department).AsQueryable();
            if (search != null)
                queryable = queryable.Where(x => x.Title.Contains(search));
            switch (OrderBy)
            {
                case enOrderingResearchEnum.ResearchID:
                    { queryable = queryable.OrderBy(x => x.ID); break; }
                case enOrderingResearchEnum.ScholarID:
                    { queryable = queryable.OrderBy(x => x.ScholarID); break; }
                case enOrderingResearchEnum.DepartmentID:
                    { queryable = queryable.OrderBy(x => x.DepartmentID); break; }
                default:
                    break;

            }
            return queryable;

        }

        public async Task<Research> GetResearchByIdWithIncludeAsync(int id)
        {
            
            var Research = await _researchRepository.GetTableNoTracking()
                .Include(x => x.department)
                .Include(r=>r.scholar)
                .Include(r=>r.Supervisor)
                .Where(x => x.ID == id).FirstOrDefaultAsync();
            return Research;
        }

        public IQueryable<Research> GetResearchByQueryable(Expression<Func<Research, bool>> predicate)
        {
            return _researchRepository.GetTableNoTracking().Where(predicate).AsQueryable();
        }
    }
}
