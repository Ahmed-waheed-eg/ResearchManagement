using MediatR;
using ResearchManage.Application.Features.Department.Queries.Respones;
using ResearchManage.Application.ResponseBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Department.Queries.Models
{
    public class GetDepartmentByIdWithResearchesQuery :IRequest<MyResponse<GetDepartmentByIdWithResearchesRespone>>
    {
        public int DepartmentID { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
