using MediatR;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Users.Command.Models
{
    public class ChangePasswordCommand : IRequest<MyResponse<bool>>
    {
        public string Id { get; set; } = default!;
        public string OldPassword { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
