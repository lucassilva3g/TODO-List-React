namespace Todo.Service.UnitTest._Helpers;

public static class XunitHelpers
{
    public static IEnumerable<object[]> StringNullOrEmptyOrWhiteSpace()
    {
        yield return new object[] { null };
        yield return new object[] { "" };
        yield return new object[] { " " };
    }

    public static IEnumerable<object[]> StringNullOrEmpty()
    {
        yield return new object[] { null };
        yield return new object[] { "" };
    }
}
