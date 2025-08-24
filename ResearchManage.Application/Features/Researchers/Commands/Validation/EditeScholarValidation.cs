using FluentValidation;
using ResearchManage.Application.Features.Researchers.Commands.Models;
using ResearchManage.Services.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Features.Researchers.Commands.Validation
{
    public class EditeScholarValidation : AbstractValidator<EditeScholarCommand>
    {
        #region Fields
        private readonly IScholarServices _scholarServices;

        #endregion

        #region Constructors

        public EditeScholarValidation(IScholarServices scholarServices)
        {
            _scholarServices = scholarServices;
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
            RuleFor(x => x.DepartmentID).GreaterThan(0).WithMessage("must greater then 0");

        }

        public void ApplyCustomValidation()
        {

            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => await _scholarServices.IsExistExcludeSelf(Key,model.Id))
                .WithMessage("this name is already exist");
        }

        #endregion

    }
}
