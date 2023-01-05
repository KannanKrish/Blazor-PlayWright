//namespace Brushtail.AspNetCore.Blazor;

//public class RoleCreator : IStartupServiceAsync
//{
//    private readonly RoleManager<ApplicationRole> roleManager;
//    private readonly UserManager<ApplicationUser> userManager;

//    public RoleCreator(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
//    {
//        this.roleManager = roleManager;
//        this.userManager = userManager;
//    }

//    public async Task DoWorkAsync()
//    {
//        await roleManager.AddRolesAsync<ApplicationRole, AccountLevel>();

//        await userManager.CreateUsersAsync(new UserModel<AccountLevel>("kannan", "Super@321", AccountLevel.Owner));
//    }
//}