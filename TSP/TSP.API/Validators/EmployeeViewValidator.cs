using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.API.ViewModels;

namespace TSP.API.Validators
{
    public class EmployeeViewValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field doesn't empty!").LessThan("3");
            RuleFor(x => x.SecondName).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field doesn't empty!").LessThan("3");
            RuleFor(x => x.Patronomic).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field doesn't empty!").LessThan("3");
            RuleFor(x => x.Age).GreaterThan(18);
            RuleFor(x => x.Position).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field doesn't empty!").LessThan("3");
            RuleFor(x => x.OfficeId).GreaterThan(0);
        }
    }
}
