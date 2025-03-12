using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using RestaurantApp.Models;
using RestaurantApp.Data;
public class ApplicationUserManager : UserManager<ApplicationUser>
{
    public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }

    public static ApplicationUserManager Create()
    {
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new AuthDbContext()));

        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        {
            RequireUniqueEmail = true
        };

        manager.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 6
        };

        return manager;
    }
}

public class ApplicationRoleManager : RoleManager<ApplicationRole>
{
    public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore) : base(roleStore) { }

    public static ApplicationRoleManager Create()
    {
        return new ApplicationRoleManager(new RoleStore<ApplicationRole>(new AuthDbContext()));
    }
}