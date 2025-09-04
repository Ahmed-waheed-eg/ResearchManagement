using MediatR;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Users.Command.Models
{
    public class DeleteUserCommand : IRequest<MyResponse<bool>>
    {
        public string Id { get; set; } = default!;
    }
}
