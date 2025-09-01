using AutoMapper;
using ResearchManage.Application.Features.Research.Queries.Respones;
using ResearchManage.Domain.Entities;

namespace ResearchManage.Application.Mapping.ResearchMapping
{
    public partial class ResearchProfil 
    {
        public void GetResearchById()
        {
            CreateMap<Research, GetResearchByIdResponse>()
                .ForMember(r => r.SupervisorID, Des => Des.MapFrom(r => r.SupervisorID))
                .ForMember(r => r.SupervisorName, Des => Des.MapFrom(r => r.Supervisor.Name))
                .ForMember(r => r.ScholarId, Des => Des.MapFrom(r => r.ScholarID))
                .ForMember(r => r.scholarName, Des => Des.MapFrom(r => r.scholar.Name))
                .ForMember(r => r.DepartmentID, Des => Des.MapFrom(r => r.DepartmentID))
                .ForMember(r => r.DepartmentName, Des => Des.MapFrom(r => r.department.Name));
                //.ReverseMap();

        }
    }
}