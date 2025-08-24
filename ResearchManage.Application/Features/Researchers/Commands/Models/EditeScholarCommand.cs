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
    public class EditeScholarCommand:IRequest<MyResponse<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public int DepartmentID { get; set; }
    }
}
