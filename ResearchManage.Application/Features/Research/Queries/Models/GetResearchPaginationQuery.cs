using Azure;
using MediatR;
using ResearchManage.Application.Features.Research.Queries.Respones;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Research.Queries.Models
{
    public class GetResearchPaginationQuery:IRequest<PaginatedList<GetResearchPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public enOrderingResearchEnum OrderBy { get; set; }
        public string? SearchonData { get; set; }
    }
}
