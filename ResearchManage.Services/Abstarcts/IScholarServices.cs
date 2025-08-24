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
    public interface IScholarServices
    {
        public Task<List<Scholar>> GetScholarListAsync();
        public Task<Scholar> GetScholarByIdWithIncludeAsync(int id);
        public Task<Scholar> GetByIdAsync(int id);


        public Task<string> AddAsync(Scholar researcher);
        public Task<string> DeleteAsync(Scholar researcher);
        public Task<string> EditeAsync(Scholar researcher);
        public Task<bool> IsExist(string name);
        public Task<bool> IsExistExcludeSelf(string name,int id);

        public IQueryable<Scholar> GetScholarQueryable();
        public IQueryable<Scholar> GetScholarByQueryable(Expression<Func<Scholar, bool>> predicate);
        public IQueryable<Scholar> FilterScholarQueryble(enOrderingScholarEnum OrderBy, string search);

  }
}
