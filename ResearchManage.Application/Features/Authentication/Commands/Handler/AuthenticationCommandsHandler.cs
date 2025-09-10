using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Authentication.Commands.Models;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Authentication.Commands.Handler
{
    public class AuthenticationCommandsHandler : MyResponseHandler,
        IRequestHandler<SignInCommand, MyResponse<string>>
    {
        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AuthenticationCommandsHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> stringLoca, SignInManager<User> signInManager, IAuthenticationService authenticationService) : base(stringLoca)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
            _stringLocalizer = stringLoca;
            _signInManager = signInManager;

        }

        #endregion


        public async Task<MyResponse<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user1 = await _userManager.FindByNameAsync(request.UserName);
            if (user1 == null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotExist]);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user1, request.Password, false);
            if (!signInResult.Succeeded)
                return BadRequest<string>(SharedResourcesKeys.IncorrectPassword);
            var accessToken = await _authenticationService.GetJWTTokenAsync(user1);
            return Success(accessToken);

        }

    }
}
