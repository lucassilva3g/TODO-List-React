namespace Todo.Service.Application.Settings.FluentValidations;

public static class FluentValidationErrorCode
{
    public static string GreaterThanValidator => "GTV";
    public static string LessThanOrEqualValidation => "LTEV";
    public static string EntityNotFoundValidation => "ENFV";
    public static string NotEmptyValidation => "NEE";
    public static string MaxLengthValidation => "MLV";
    public static string CnpjValidation => "CNPJV";
    public static string EntityExistsValidation => "EEV";
}

