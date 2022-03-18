using FluentValidation.Results;

namespace Minimal.Extensions;

public static class FluentValidationExtensions
{
    public static IDictionary<string, string[]> ToDictionary(this ValidationResult validationResult)
    => validationResult.Errors
        .GroupBy(x => x.PropertyName)
        .ToDictionary(
        g => g.Key,
        g => g.Select(x => x.ErrorMessage).ToArray()
        );

}
