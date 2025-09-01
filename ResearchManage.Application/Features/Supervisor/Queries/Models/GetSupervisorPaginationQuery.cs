using MediatR;
using ResearchManage.Application.Features.Supervisor.Queries.Respones;
using ResearchManage.Application.Pagination;

namespace ResearchManage.Application.Features.Supervisor.Queries.Models
{
    public class GetSupervisorPaginationQuery : IRequest<PaginatedList<GetSupervisorPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchonData { get; set; }
    }
}
