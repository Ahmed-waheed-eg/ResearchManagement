using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Users.Command.Models;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Resources;

namespace ResearchManage.Application.Features.Users.Command.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors

        public ChangePasswordValidator(UserManager<User> userManager, IStringLocalizer<SharedResources> stringLoc)
        {
            _userManager = userManager;
            _stringLocalizer = stringLoc;
            ApplyValidationRules();
            ApplyCustomValidationRules();


        }

        #endregion

        private void ApplyValidationRules()
        {
            RuleFor(u => u.ConfirmPassword)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .Equal(u => u.Password).WithMessage($"{SharedResourcesKeys.InvalidConfirmPassword}");
        }
        private void ApplyCustomValidationRules()
        {
            //Check if user is Exist by Id
            RuleFor(u => u.Id).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByIdAsync(key) is not null;
            }).WithMessage(SharedResourcesKeys.Invalid);
        }
    }
}
