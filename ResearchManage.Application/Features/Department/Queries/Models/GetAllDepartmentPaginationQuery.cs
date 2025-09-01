using MediatR;
using ResearchManage.Application.Features.Department.Queries.Respones;
using ResearchManage.Application.Pagination;

namespace ResearchManage.Application.Features.Department.Queries.Models
{
    public class GetAllDepartmentPaginationQuery : IRequest<PaginatedList<GetAllDepartmentPaginationResnose>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchonData { get; set; }
    }
}
