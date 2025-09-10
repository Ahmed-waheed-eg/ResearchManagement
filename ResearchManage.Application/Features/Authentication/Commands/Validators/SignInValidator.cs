using FluentValidation;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Authentication.Commands.Models;
using ResearchManage.Domain.Resources;

namespace ResearchManage.Application.Features.Authentication.Commands.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors

        public SignInValidator(IStringLocalizer<SharedResources> stringLoc)
        {
            _stringLocalizer = stringLoc;
            ApplyValidationRules();
        }

        #endregion

        private void ApplyValidationRules()
        {
            RuleFor(s => s.UserName)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

            RuleFor(s => s.Password)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
        }
    }
}
