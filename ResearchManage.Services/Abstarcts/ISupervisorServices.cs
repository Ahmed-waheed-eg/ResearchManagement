using ResearchManage.Domain.Entities;

namespace ResearchManage.Services.Abstarcts
{
    public interface ISupervisorServices
    {
        Task<Supervisor> GetSupervisorByIdWithIncludeAsync(int id);
        public IQueryable<Supervisor> FilterSupervisorQueryble(string search);

    }
}
