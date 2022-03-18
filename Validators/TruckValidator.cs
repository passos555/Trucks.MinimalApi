using FluentValidation;
using Minimal.Models;

namespace Minimal.Validators;

public class TruckValidator : AbstractValidator<Truck>
{
    public TruckValidator()
    {
        var currentYear = DateTime.Now.Year;
        var nextYear = currentYear + 1;

        RuleFor(x => x.ManufacturingDate)
        .NotEmpty().WithMessage("Manufacturing Date is required.");

        RuleFor(x => x.ManufacturingDate.Year)
        .Equal(currentYear).WithMessage("Manufacturing Year is invalid.");

        RuleFor(x => x.ModelDate)
        .NotEmpty().WithMessage("Model Date is required.");

        RuleFor(x => x.ModelDate.Year)
        .InclusiveBetween(currentYear, nextYear).WithMessage("Model Year is invalid.");

        RuleFor(x => x.Model)
        .NotEmpty().WithMessage("Model is required.")
        .IsInEnum().WithMessage("Invalid truck model.");
    }
}
