using ResearchManage.Application.Features.Researchers.Commands.Models;
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
        public void EditeResercherCommandMapping()
        {
            CreateMap<EditeScholarCommand, Scholar>()
                .ForMember(ders => ders.DepartmentID, opt => opt.MapFrom(src => src.DepartmentID))
                .ForMember(ders => ders.ID, opt => opt.MapFrom(src=>src.Id))
                .ReverseMap();
        }
    }
}