using FluentValidation;
using TODO.Service.Domain.Utils;

namespace TODO.Service.Application.Settings.FluentValidations;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, string> Cnpj<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(value => value.IsValidCnpj());
    }
}
