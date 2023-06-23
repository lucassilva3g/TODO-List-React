namespace Todo.Service.UnitTest.Domain.Utils.UtilsTests;

public class UtilsTest_IsNullOrEmpty
{
    [Theory]
    [MemberData(nameof(XunitHelpers.StringNullOrEmpty), MemberType = typeof(XunitHelpers))]
    public void Must_Return_True_When_Input_Is_Null_Or_Empty(string value)
    {
        var result = value.IsNullOrEmpty();

        Assert.True(result);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("ads")]
    [InlineData("test")]
    [InlineData(" test")]
    public void Must_Return_False_When_Input_Is_Filled(string value)
    {
        var result = value.IsNullOrEmpty();

        Assert.False(result);
    }
}
