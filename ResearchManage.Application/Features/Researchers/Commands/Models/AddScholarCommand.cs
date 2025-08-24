using MediatR;
using ResearchManage.Application.ResponseBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Commands.Models
{
    public class AddScholarCommand :IRequest<MyResponse<string>>
    {
       [Required]
        public string Name { get; set; }

        public string? Bio {  get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}
