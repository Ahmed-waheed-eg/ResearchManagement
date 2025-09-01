using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Users.Command.Models;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Resources;

namespace ResearchManage.Application.Features.Users.Command.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors

        public CreateUserValidator(UserManager<User> userManager, IStringLocalizer<SharedResources> stringLoc)
        {
            _userManager = userManager;
            _stringLocalizer = stringLoc;
            ApplyValidation();
            ApplyCustomValidation();


        }

        #endregion

        #region Actions
        public void ApplyValidation()
        {
            RuleFor(u => u.FirstName)
                 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .MaximumLength(256).WithMessage($"{SharedResourcesKeys.MaxLength} 256");

            RuleFor(u => u.LastName)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
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



            RuleFor(u => u.ConfirmPassword)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .Equal(u => u.Password).WithMessage($"{SharedResourcesKeys.InvalidConfirmPassword}");

        }

        public void ApplyCustomValidation()
        {
            RuleFor(u => u.UserName).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByNameAsync(key) is null;
            }).WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

            RuleFor(u => u.Email).MustAsync(async (key, CancellationToken) =>
            {
                return await _userManager.FindByEmailAsync(key) is null;
            }).WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);
        }

        #endregion

    }
}
