using MediatR;
using ResearchManage.Application.Features.Research.Queries.Respones;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Research.Queries.Models
{
    public class GetResearchByIdQuery:IRequest<MyResponse<GetResearchByIdResponse>>
        {
        public int Id { get; set; }
        public GetResearchByIdQuery(int id)
        {
            Id = id;
        }
    }
}
