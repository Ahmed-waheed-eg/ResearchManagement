using MediatR;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<MyResponse<string>>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
