using Microsoft.EntityFrameworkCore;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Infrustructure.Data;
using ResearchManage.Infrustructure.GenericBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Infrustructure.Repositories
{
    public class ScholarRepository(ApplicationDBContext _dbContext) : GenericRepo<Scholar>(_dbContext) ,IScholarRepository
    {
        #region  Handels functions
        public async Task<List<Scholar>> GetScholarListAsync()
        {
            return await _dbContext.Scholars.Include(r=>r.Department).ToListAsync();
        }
        #endregion
    }
}
