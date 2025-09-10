using MediatR;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Helpers;

namespace ResearchManage.Application.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<MyResponse<JwtAuthTokenResponse>>
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
    }
}
