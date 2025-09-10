using MediatR;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Authentication.Queries.Models;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueriesHandler : MyResponseHandler,
       IRequestHandler<GetAccessTokenValidityQuery, MyResponse<string>>
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors
        public AuthenticationQueriesHandler(IAuthenticationService authenticationService, IStringLocalizer<SharedResources> stringLoca) : base(stringLoca)
        {
            _stringLocalizer = stringLoca;
            _authenticationService = authenticationService;

        }
        #endregion

        public async Task<MyResponse<string>> Handle(GetAccessTokenValidityQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateAccessTokenAsync(request.AccessToken);
            if (result == "NotExpired") return Success("Not Expired");

            return Unauthorized<string>(result);

        }

    }
}
