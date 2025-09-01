using Microsoft.EntityFrameworkCore;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Services.Implementation
{
    public class SupervisorServices(ISupervisorRepository supervisorRepository) : ISupervisorServices
    {
        public IQueryable<Supervisor> FilterSupervisorQueryble(string search)
        {
            var sup = supervisorRepository.GetTableNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                sup = sup.Where(d => d.Name.Contains(search));
            }
            return sup;
        }

        public async Task<Supervisor> GetSupervisorByIdWithIncludeAsync(int id)
        {
            var Supervisor = await supervisorRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .Where(x => x.ID == id).FirstOrDefaultAsync();
            return Supervisor;
        }
    }
}
