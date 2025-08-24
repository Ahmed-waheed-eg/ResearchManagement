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
    public class GetDepartmentByIdQuery:IRequest<MyResponse< GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id) { Id = id; }
    }
}
