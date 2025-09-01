using MediatR;
using ResearchManage.Application.Features.Users.Queries.Results;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Users.Queries.Models
{
    public class GetAllUsersQuery : IRequest<MyResponse<List<GetAllUsersResponse>>>
    {
    }
}
