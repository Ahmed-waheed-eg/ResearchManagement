using ResearchManage.Domain.Entities;

namespace ResearchManage.Services.Abstarcts
{
    public interface IDepartmentServices
    {

        public Task<Department> GetDepartmentById(int id);
        public IQueryable<Department> FilterResearchQueryble(string search);

        public Task<bool> IsExist(int id);
    }
}
