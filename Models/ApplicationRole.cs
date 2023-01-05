namespace BlazorApp.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() { }

    public ApplicationRole(string name) : base(name) { }

    public ApplicationRole(string name, string description) : base(name) => Description = description;

    public string Description { get; set; }
}