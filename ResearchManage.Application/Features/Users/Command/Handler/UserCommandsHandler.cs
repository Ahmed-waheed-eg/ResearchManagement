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
        IRequestHandler<CreateUserCommand, MyResponse<string>>,
        IRequestHandler<EditUserCommand, MyResponse<string>>,
        IRequestHandler<DeleteUserCommand, MyResponse<bool>>
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

        public async Task<MyResponse<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByIdAsync(request.Id);
            var user = _mapper.Map(request, oldUser);

            var updatedUser = await _userManager.UpdateAsync(user);
            if (!updatedUser.Succeeded)
                return BadRequest<string>(updatedUser.Errors.FirstOrDefault().Description);
            return Success("Successfully");

        }

        public async Task<MyResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
                return NotFound<bool>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var isDeleted = await _userManager.DeleteAsync(user);
            if (!isDeleted.Succeeded)
                return BadRequest<bool>(isDeleted.Errors.FirstOrDefault().Description);

            return Deleted<bool>();
        }
    }
}
