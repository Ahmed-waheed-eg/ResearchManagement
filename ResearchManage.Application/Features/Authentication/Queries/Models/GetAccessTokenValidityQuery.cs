using MediatR;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Authentication.Queries.Models
{
    public class GetAccessTokenValidityQuery : IRequest<MyResponse<string>>
    {
        public string AccessToken { get; set; } = default!;
    }
}
