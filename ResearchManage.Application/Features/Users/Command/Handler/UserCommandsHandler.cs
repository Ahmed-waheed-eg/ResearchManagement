using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Users.Command.Models;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Resources;

namespace ResearchManage.Application.Features.Users.Command.Handler
{
    public class UserCommandsHandler : MyResponseHandler,
        IRequestHandler<CreateUserCommand, MyResponse<string>>
    {
        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public UserCommandsHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> stringLoca) : base(stringLoca)
        {
            _mapper = mapper;
            _stringLocalizer = stringLoca;
            _userManager = userManager;

        }

        #endregion

        public async Task<MyResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            try
            {
                var uuser = await _userManager.CreateAsync(user, request.Password);
                if (!uuser.Succeeded) return BadRequest<string>(uuser.Errors.FirstOrDefault().Description);
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message.ToString());
            }
            return Success<string>("done");
        }

    }
}
