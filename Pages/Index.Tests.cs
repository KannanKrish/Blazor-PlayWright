namespace BlazorApp.Pages;

[TestClass]
public class IndexPageTests : BlazorTest
{
    [DataTestMethod]
    [DataRow("/", "Index")]
    [DataRow("/counter", "Counter")]
    [DataRow("/fetchdata", "Weather Forecast")]
    [DataRow("/swagger", "Swagger UI")]
    public async Task PageTests(string url, string expectedTitle)
    {
        await Page.GotoAsync(url);

        var title = await Page.TitleAsync();

        title.ShouldBe(expectedTitle);
    }
}