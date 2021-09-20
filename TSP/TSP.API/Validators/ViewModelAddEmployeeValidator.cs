using FluentValidation;
using TSP.API.ViewModels;

namespace TSP.API.Validators
{
    public class ViewModelAddEmployeeValidator : AbstractValidator<EmployeeAddViewModel>
    {
        public ViewModelAddEmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field is not meant to be empty!").MinimumLength(3);
            RuleFor(x => x.SecondName).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field is not meant to be empty!").MinimumLength(3);
            RuleFor(x => x.Patronomic).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field is not meant to be empty!").MinimumLength(3);
            RuleFor(x => x.Age).GreaterThan(18);
            RuleFor(x => x.Position).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("This field is not meant to be empty!").MinimumLength(3);
            RuleFor(x => x.OfficeId).GreaterThan(0);
        }
    }
}