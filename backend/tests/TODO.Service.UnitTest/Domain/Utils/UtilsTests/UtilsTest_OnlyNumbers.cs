namespace Todo.Service.UnitTest.Domain.Utils.UtilsTests;

public class UtilsTest_OnlyNumbers
{
    [Theory]
    [MemberData(nameof(XunitHelpers.StringNullOrEmpty), MemberType = typeof(XunitHelpers))]
    public void Must_Return_Input_When_Input_Is_Null_Or_Empty(string value)
    {
        var result = value.OnlyNumbers();

        Assert.Equal(value, result);
    }

    [Theory]
    [InlineData(" ", "")]
    [InlineData("ads", "")]
    [InlineData("test 1", "1")]
    [InlineData("1 8tes9t", "189")]
    public void Must_Return_Expected(string value, string expected)
    {
        var result = value.OnlyNumbers();

        Assert.Equal(expected, result);
    }
}
