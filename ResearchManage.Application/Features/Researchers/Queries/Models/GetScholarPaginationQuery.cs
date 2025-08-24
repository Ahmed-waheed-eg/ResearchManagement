using MediatR;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.Pagination;
using ResearchManage.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Queries.Models
{
    public class GetScholarPaginationQuery :IRequest<PaginatedList<GetScholarPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public enOrderingScholarEnum OrderBy { get; set; }
        public string? SearchonData { get; set; }
        

    }
}
