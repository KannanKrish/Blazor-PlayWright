namespace BlazorApp.Data;

public partial class ApplicationDbContext : BaseIdentityDbContext<Guid, ApplicationUser, ApplicationRole>
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
}