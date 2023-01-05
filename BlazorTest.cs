namespace BlazorApp;

[TestClass]
public class BlazorTest : PageTest
{
    private static WebApplication app = null!;

    [AssemblyInitialize]
    public static void AssemblyInitialize2(TestContext context)
    {
        Console.Error.WriteLine("AssemblyInitialize");

        var baseDir = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");

        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = "Development",
            ContentRootPath = baseDir,
            WebRootPath = Path.Combine(baseDir, "wwwroot"),
            ApplicationName = "BlazorApp",
        });

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddSmartBackend<ApplicationDbContext>();

        app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
            app.UseExceptionHandler("/Error");

        app.UseStaticFiles();

        app.UseRouting();

        app.UseSmartBackend();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        var readyTcs = new CancellationTokenSource();

        _ = Task.Run(async () =>
        {
            await app.StartAsync(readyTcs.Token);

            readyTcs.Cancel();
        }, readyTcs.Token).ConfigureAwait(false);

        readyTcs.Token.WaitHandle.WaitOne();
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup() => await app.StopAsync();

    public override BrowserNewContextOptions ContextOptions()
    {
        // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
        var options = base.ContextOptions() ?? new BrowserNewContextOptions();

        options.BaseURL = "http://localhost:5000";

        return options;
    }
}