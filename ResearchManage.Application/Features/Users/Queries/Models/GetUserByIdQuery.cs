using MediatR;
using ResearchManage.Application.Features.Users.Queries.Results;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<MyResponse<GetUserByIdResponse>>
    {
        public string Id { get; set; } = default!;

    }
}
