using FluentValidation;
using TSP.API.ViewModels;

namespace TSP.API.Validators
{
    public class ViewModelUpdateOfficeValidator : AbstractValidator<OfficeUpdateViewModel>
    {
        public ViewModelUpdateOfficeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").WithMessage("Name can't be empty").MaximumLength(60).MinimumLength(3);
            RuleFor(x => x.Address).NotEmpty().Matches("^[A - Za - z0 - 9'\\.\\-\\s\\,]").MaximumLength(60).MinimumLength(3);
            RuleFor(x => x.Country).NotEmpty().Matches("^[A-Z][a-zA-Z]*$").MaximumLength(20);
        }
    }
}