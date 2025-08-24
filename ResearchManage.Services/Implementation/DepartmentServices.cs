using ResearchManage.Domain.Entities;
using ResearchManage.Services.Abstarcts;
using Microsoft.EntityFrameworkCore;
using ResearchManage.Infrustructure.Abstracts;
namespace ResearchManage.Services.Implementation
{
    public class DepartmentServices(IDepartmentRepository _DepartmentRepository) : IDepartmentServices
    {
        public async Task<Department> GetDepartmentById(int id)
        {
           var department =await _DepartmentRepository.GetTableNoTracking().Where(d=>d.ID.Equals(id))
                .Include(d=>d.Scholars)
                .Include(d=>d.Supervisors).FirstOrDefaultAsync();
            return department;
        }

        public async Task<Department> GetDepartmentByIdWithResearches(int id)
        {
            var department = await _DepartmentRepository.GetTableNoTracking().Where(d => d.ID.Equals(id))
                 .Include(d => d.Researches).FirstOrDefaultAsync();
            return department;
        }

        public async Task<Department> GetDepartmentByIdWithSuberVisor(int id)
        {
            var department = await _DepartmentRepository.GetTableNoTracking().Where(d => d.ID.Equals(id))
                 .Include(d => d.Supervisors).FirstOrDefaultAsync();
            return department;
        }
        public async Task<Department> GetDepartmentByIdWithScholars(int id)
        {
            var department = await _DepartmentRepository.GetTableNoTracking().Where(d => d.ID.Equals(id))
                 .Include(d => d.Scholars).FirstOrDefaultAsync();
            return department;
        }
    }
}
