var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazorJwtAuthentication<Guid, ApplicationUser, ApplicationRole, ApplicationDbContext>()
    .AddSmartBackend<ApplicationDbContext>()
    .AddSmartUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) 
    app.UseExceptionHandler("/Error");

app.UseStaticFiles();

app.UseRouting();

app.UseSmartBackend();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();