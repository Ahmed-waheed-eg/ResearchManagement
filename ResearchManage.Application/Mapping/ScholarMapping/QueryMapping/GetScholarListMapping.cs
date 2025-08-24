using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Mapping.ScholarMapping
{
    public partial class ScholarProfile
    {
        public void GetScholarListMapping()
        {
            CreateMap<Scholar, ScholarDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ReverseMap();
        }
    }
}
