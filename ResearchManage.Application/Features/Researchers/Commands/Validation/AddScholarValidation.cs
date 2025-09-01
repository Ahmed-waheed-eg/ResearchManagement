
using FluentValidation;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Researchers.Commands.Models;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Researchers.Commands.Validation
{
    public class AddScholarValidation : AbstractValidator<AddScholarCommand>
    {
        #region Fields
        private readonly IScholarServices _ScholarServices;
        private readonly IDepartmentServices _departmentServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors

        public AddScholarValidation(IScholarServices scholarServices, IStringLocalizer<SharedResources> stringLoc, IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
            _ScholarServices = scholarServices;
            _stringLocalizer = stringLoc;
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
            RuleFor(x => x.DepartmentID)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage("must greater then 0");

        }

        public void ApplyCustomValidation()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => await _ScholarServices.IsExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

            RuleFor(x => x.DepartmentID)
              .MustAsync(async (Key, CancellationToken) => await _departmentServices.IsExist(Key))
              .WithMessage(_stringLocalizer[SharedResourcesKeys.NotExist]);
        }

        #endregion

    }
}
