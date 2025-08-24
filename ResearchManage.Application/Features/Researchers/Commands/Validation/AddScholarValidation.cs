
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResearchManage.Application.Features.Researchers.Commands.Models;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Researchers.Commands.Validation
{
    public class AddScholarValidation  : AbstractValidator<AddScholarCommand>
    {
        #region Fields
        private readonly IScholarServices _ScholarServices;

        #endregion

        #region Constructors

        public AddScholarValidation(IScholarServices scholarServices) 
        {
             _ScholarServices= scholarServices;
            ApplyValidation();
            ApplyCustomValidation();


        }

        #endregion

        #region Actions
        public void ApplyValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull().WithMessage("name should be not null")
                .MaximumLength(30).WithMessage("Max lenth is 30");
            RuleFor(x=>x.DepartmentID).GreaterThan(0).WithMessage("must greater then 0");

        }

        public void ApplyCustomValidation()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => await _ScholarServices.IsExist(Key))
                .WithMessage("this name is already exist");
        }

        #endregion

    }
}
