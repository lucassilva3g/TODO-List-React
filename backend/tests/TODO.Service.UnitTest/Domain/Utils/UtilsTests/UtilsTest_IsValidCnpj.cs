namespace Todo.Service.UnitTest.Domain.Utils.UtilsTests;

public class UtilsTest_IsValidCnpj
{
    [Theory]
    [MemberData(nameof(XunitHelpers.StringNullOrEmptyOrWhiteSpace), MemberType = typeof(XunitHelpers))]
    public void Must_Return_False_When_Input_Is_Null_Empty_Or_White_Space(string value)
    {
        var result = value.IsValidCnpj();

        Assert.False(result);
    }

    [Theory]
    [InlineData("1234567890123")]
    [InlineData("123456789012345")]
    public void Must_Return_False_When_Input_Length_Is_Diff_From_14(string value)
    {
        var result = value.IsValidCnpj();

        Assert.False(result);
    }

    [Theory]
    [InlineData("12345678901234")]
    [InlineData("12345678901224")]
    public void Must_Return_False_When_Input_Length_Is_Invalid(string value)
    {
        var result = value.IsValidCnpj();

        Assert.False(result);
    }

    [Theory]
    [InlineData("55.252.388/0001-00")]
    [InlineData("44.418.160/0001-20")]
    [InlineData("55691102000192")]
    [InlineData("74956978000168")]
    public void Must_Return_True_When_Input_Length_Is_Valid(string value)
    {
        var result = value.IsValidCnpj();

        Assert.True(result);
    }
}
