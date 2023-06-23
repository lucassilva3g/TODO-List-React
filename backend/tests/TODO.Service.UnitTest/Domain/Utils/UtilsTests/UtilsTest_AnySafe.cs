namespace Todo.Service.UnitTest.Domain.Utils.UtilsTests;

public class UtilsTest_AnySafe
{
    [Fact]
    public void Must_Return_True()
    {
        var list = new List<int> { 1 };

        var result = list.AnySafe();

        Assert.True(result);
    }

    [Fact]
    public void Must_Return_False()
    {
        var list = new List<int>();

        var result = list.AnySafe();

        Assert.False(result);
    }

    [Fact]
    public void Must_Return_False_When_List_Is_Null()
    {
        List<int> list = null;

        var result = list.AnySafe();

        Assert.False(result);
    }

    [Fact]
    public void Must_Return_False_When_List_Is_Empty()
    {
        var newList = Enumerable.Empty<int>();

        var result = newList.AnySafe();

        Assert.False(result);
    }
}
