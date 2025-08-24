

using ResearchManage.Application.Features.Department.Queries.Respones;
using ResearchManage.Domain.Entities;

namespace ResearchManage.Application.Mapping.DepartmentMapping
{
    public partial class DepartmentProfil 
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>();
            CreateMap<Scholar, ScholarsDTORespons>();
            CreateMap<Supervisor,SuperVisorDTORespons>();


        }

    }
}