using MediatR;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Helpers;

namespace ResearchManage.Application.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<MyResponse<JwtAuthTokenResponse>>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
