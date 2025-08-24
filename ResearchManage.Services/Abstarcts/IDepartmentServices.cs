using ResearchManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Services.Abstarcts
{
    public interface IDepartmentServices
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
