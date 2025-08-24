using MediatR;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities;

namespace ResearchManage.Application.Features.Researchers.Queries.Models
{
    public class GetScholarsListQuery : IRequest<MyResponse<List<ScholarDTO>>>
    {
    }
}
