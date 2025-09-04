using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Users.Command.Models;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Resources;

namespace ResearchManage.Application.Features.Users.Command.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors

        public EditUserValidator(UserManager<User> userManager, IStringLocalizer<SharedResources> stringLoc)
        {
            _userManager = userManager;
            _stringLocalizer = stringLoc;
            ApplyValidationRules();
            ApplyCustomValidationRules();


        }

        #endregion


        private void ApplyValidationRules()
        {
            RuleFor(u => u.FirstName)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.LastName)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.UserName)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.Email)
            .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage($"{SharedResourcesKeys.InvalidEmail}");


            RuleFor(u => u.PhoneNumber)
            .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            .Matches(@"^(?:\+?20|0020|0)?1[0125]\d{8}$").WithMessage($"{SharedResourcesKeys.InvalidPhone}");

        }
        private void ApplyCustomValidationRules()
        {
            RuleFor(u => u.Id).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByIdAsync(key) is not null;
            }).WithMessage(_stringLocalizer[SharedResourcesKeys.NotFound]);

            RuleFor(u => u.UserName).MustAsync(async (model, key, CancellationToken) =>
            {
                var user = await _userManager.FindByNameAsync(key);
                return !(user is not null && model.Id != user.Id);
            }).WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

            RuleFor(u => u.Email).MustAsync(async (model, key, CancellationToken) =>
            {
                var user = await _userManager.FindByEmailAsync(key);
                return !(user is not null && model.Id != user.Id);
            }).WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

            RuleFor(u => u.Password).MustAsync(async (model, key, CancellationToken) =>
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                return await _userManager.CheckPasswordAsync(user, key);
            }).WithMessage(SharedResourcesKeys.IncorrectPassword);
        }
    }

}
