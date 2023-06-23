namespace Todo.Service.Domain.Utils;

public static class Utils
{
    const int CNPJ_LENGTH = 14;

    public static bool AnySafe<T>(this IEnumerable<T> source) => source != null && source.Any();

    public static bool IsNullOrEmpty(this string src) => string.IsNullOrEmpty(src);

    public static bool IsNullOrWhiteSpace(this string src) => string.IsNullOrWhiteSpace(src);

    public static string OnlyNumbers(this string src) => !src.IsNullOrEmpty() ? new string(src.Where(e => char.IsDigit(e)).ToArray()) : src;

    public static bool IsValidCnpj(this string src)
    {
        if (src.IsNullOrEmpty()) return false;

        src = src.OnlyNumbers();

        if (src.Length != CNPJ_LENGTH)
            return false;

        var multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var sum = 0;

        string digit, tempSrc;

        tempSrc = src[..12];

        for (int i = 0; i < 12; i++)
            sum += int.Parse(tempSrc[i].ToString()) * multiplier1[i];

        digit = GetDigit(sum);

        tempSrc += digit;

        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(tempSrc[i].ToString()) * multiplier2[i];

        digit += GetDigit(sum);

        return src.EndsWith(digit);
    }

    private static string GetDigit(int sum)
    {
        var rest = sum % 11;

        rest = rest < 2 ? 0 : 11 - rest;

        return rest.ToString();
    }
}
