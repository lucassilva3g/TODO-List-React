using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Todo.Service.Domain.Resources;

public class Messages
{
    private readonly IStringLocalizer _localizer;

    public Messages(IStringLocalizerFactory factory)
    {
        var type = typeof(Messages);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName!);
        _localizer = factory.Create("Messages", assemblyName.Name);
    }

    public string GetMessage(string key)
    {
        var item = _localizer[key];
        return item.ResourceNotFound ? "" : item.Value;
    }

    public string GetMessage(string key, params string[] values)
    {
        var item = _localizer[key];
        if (item.ResourceNotFound)
            return "";

        var value = item.Value;

        value = string.Format(value, values);

        return value;
    }

    public static class Entities
    {
    }

    public static class Validations
    {
        public const string NOT_EMPTY = "VALIDATION_NOT_EMPTY";
        public const string MAX_LENGTH = "VALIDATION_MAX_LENGTH";
        public const string GREATER_THAN_VALUE = "VALIDATION_GREATER_THAN_VALUE";
        public const string LESS_THAN_OR_EQUAL_VALUE = "VALIDATION_LESS_THAN_OR_EQUAL_VALUE";
        public const string CNPJ = "VALIDATION_CNPJ";
    }

    public static class Exception
    {
        public const string AUTHORIZATION = "EXCEPTION_AUTH";
        public const string VALIDATION = "EXCEPTION_VALIDATION";
        public const string FORBIDDEN = "EXCEPTION_FORBIDDEN";
        public const string PERSISTENCE = "EXCEPTION_PERSISTENCE";
        public const string NOT_FOUND = "EXCEPTION_NOT_FOUND";
    }
}
