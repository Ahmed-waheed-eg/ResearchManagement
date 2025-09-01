using ResearchManage.Application.Features.Supervisor.Queries.Respones;
using ResearchManage.Domain.Entities;

namespace ResearchManage.Application.Mapping.SupervisorMapping
{
    public partial class SupervisorProfil
    {
        public void getSupervisorByIdMapping()
        {
            CreateMap<Supervisor, GetSuoervisorByIdRespons>()
                 .ForMember(x => x.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));
        }
    }
}
