namespace Hupo.Template.Shared.UnitTests;

public class StringExtensionTest
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("str", false)]
    public void IsNullOrEmpty(string? str, bool expect)
    {
        Assert.Equal(str.IsNullOrEmpty(), expect);
    }

    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("str", false)]
    public void IsNullOrWhiteSpace(string? str, bool expect)
    {
        Assert.Equal(str.IsNullOrWhiteSpace(), expect);
    }
}
