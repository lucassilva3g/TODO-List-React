namespace Todo.Service.UnitTest.Domain.Utils.UtilsTests;

public class UtilsTest_IsNullOrWhiteSpace
{
    [Theory]
    [MemberData(nameof(XunitHelpers.StringNullOrEmptyOrWhiteSpace), MemberType = typeof(XunitHelpers))]
    public void Must_Return_True_When_Input_Is_Null_Empty_Or_White_Space(string value)
    {
        var result = value.IsNullOrWhiteSpace();

        Assert.True(result);
    }

    [Theory]
    [InlineData("ads")]
    [InlineData("test")]
    [InlineData(" test")]
    public void Must_Return_False_When_Input_Is_Filled(string value)
    {
        var result = value.IsNullOrWhiteSpace();

        Assert.False(result);
    }
}
