using FluentValidation;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Researchers.Commands.Models;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Researchers.Commands.Validation
{
    public class EditeScholarValidation : AbstractValidator<EditeScholarCommand>
    {
        #region Fields
        private readonly IScholarServices _scholarServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors

        public EditeScholarValidation(IScholarServices scholarServices, IStringLocalizer<SharedResources> stringLoc)
        {
            _stringLocalizer = stringLoc;

            _scholarServices = scholarServices;
            ApplyValidation();
            ApplyCustomValidation();


        }

        #endregion

        #region Actions
        public void ApplyValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(30).WithMessage("Max lenth is 30");
            RuleFor(x => x.DepartmentID).GreaterThan(0).WithMessage("must greater then 0");

        }

        public void ApplyCustomValidation()
        {

            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => await _scholarServices.IsExistExcludeSelf(Key, model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);
        }

        #endregion

    }
}
