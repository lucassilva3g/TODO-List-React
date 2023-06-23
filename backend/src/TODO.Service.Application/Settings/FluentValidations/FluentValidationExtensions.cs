using FluentValidation;
using Todo.Service.Domain.Utils;

namespace Todo.Service.Application.Settings.FluentValidations;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, string> Cnpj<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(value => value.IsValidCnpj());
    }
}
