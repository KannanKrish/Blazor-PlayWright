namespace BlazorApp.Data;

[TestClass]
public class BlazorTest : PageTest
{
    private static WebApplication app;

    [AssemblyInitialize]
    public static void AssemblyInitialize2(TestContext context)
    {
        Console.Error.WriteLine("AssemblyInitialize");

        var baseDir = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");

        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = Environments.Development,
            ContentRootPath = baseDir,
            WebRootPath = Path.Combine(baseDir, "wwwroot"),
            ApplicationName = "BlazorApp"
        });

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddBlazorJwtAuthentication<Guid, ApplicationUser, ApplicationRole, ApplicationDbContext>()
            .AddSmartBackend<ApplicationDbContext>()
            .AddSmartUI();

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
        // ReSharper disable once ConstantNullCoalescingCondition
        var options = base.ContextOptions() ?? new BrowserNewContextOptions();

        options.BaseURL = "http://localhost:5000";

        return options;
    }
}