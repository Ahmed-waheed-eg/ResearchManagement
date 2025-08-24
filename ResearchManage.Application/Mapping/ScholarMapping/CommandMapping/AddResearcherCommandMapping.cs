using AutoMapper;
using ResearchManage.Application.Features.Researchers.Commands.Models;
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
        public void AddResercherCommandMapping()
        {
            CreateMap<AddScholarCommand, Scholar>()
                .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => src.DepartmentID))
                .ReverseMap();
        }
    }
}
