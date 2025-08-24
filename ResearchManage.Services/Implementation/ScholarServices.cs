using Microsoft.EntityFrameworkCore;
using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Helpers;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Services.Abstarcts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Services.Implementation
{
    public class ScholarServices(IScholarRepository _ScholarRepo) : IScholarServices
    {
       
        #region Handle functions
        public async Task<List<Scholar>> GetScholarListAsync()
        {
            return await _ScholarRepo.GetScholarListAsync();
        }
        
        public async Task<Scholar> GetScholarByIdWithIncludeAsync(int id)
        {
            //return await _ScholarRepo.GetByIdAsync(id);
            var scholar = await _ScholarRepo.GetTableNoTracking().Include(x => x.Department)
                .Where(x => x.ID == id).FirstOrDefaultAsync();
            return scholar;

        }

        public async Task<string> AddAsync(Scholar scholar)
        {
            //var researcherExits = _ScholarRepo.GetTableNoTracking().Where(x => x.Name.Equals(researcher.Name)).FirstOrDefault();
            //if (researcherExits != null) return "Exists";

            await _ScholarRepo.AddAsync(scholar);

            return "Success";

        }

        public async Task<bool> IsExist(string name)
        {
            var ScholarExits = _ScholarRepo.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (ScholarExits == null) return true;
            return false;
        }

        public async Task<bool> IsExistExcludeSelf(string name, int id)
        {
            var scholarExits =  _ScholarRepo.GetTableNoTracking().Where(x=>x.Name.Equals(name)&!x.ID.Equals(id)).FirstOrDefault();
            if (scholarExits == null) return true;
            return false;
        }

        public async Task<string> DeleteAsync(Scholar scholar)
        {
            var transe =  _ScholarRepo.BeginTransaction();
            try
            {
                await _ScholarRepo.DeleteAsync(scholar);
                await transe.CommitAsync();
                return "Success";
            }
            catch
            {
                transe.Rollback();
                return "failed in deleted";

            }
           
        }

        public async Task<string> EditeAsync(Scholar scholar)
        {

            await _ScholarRepo.UpdateAsync(scholar);
            return "Success";
        }

        public async Task<Scholar> GetByIdAsync(int id)
        {
           return await _ScholarRepo.GetByIdAsync(id);
            

        }

        public IQueryable<Scholar> GetScholarQueryable()
        {
            return _ScholarRepo.GetTableNoTracking().Include(x=>x.Department).AsQueryable();
        }

        public IQueryable<Scholar> FilterScholarQueryble(enOrderingScholarEnum OrderBy, string search)
        {
            
            var queryable= _ScholarRepo.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
                queryable = queryable.Where(x=>x.Name.Contains(search));
            switch(OrderBy)
            { case enOrderingScholarEnum.ScholarID:
                  {queryable= queryable.OrderBy(x => x.ID);break; }
                case enOrderingScholarEnum.DepartmentID:
                    { queryable = queryable.OrderBy(x => x.DepartmentID);break; }
                default:
                    break;
            
            }    
            return queryable;
        }

        public  IQueryable<Scholar> GetScholarByQueryable(Expression<Func<Scholar, bool>> predicate)
        {
            return  _ScholarRepo.GetTableNoTracking().Where(predicate).AsQueryable();
        }



        #endregion



    }
}
