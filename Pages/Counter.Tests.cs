namespace BlazorApp.Pages;

[TestClass]
public class CounterTests : BlazorTest
{
    [TestMethod]
    public async Task CounterTest()
    {
        await Page.GotoAsync("/");
        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Counter" }).ClickAsync();

        for (var i = 0; i < 10; i++)
        {
            await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Click me" }).ClickAsync();

            var result = await Page.GetByText($"Current count: {i + 1}").IsVisibleAsync();
            result.ShouldBe(true);
        }
    }
}