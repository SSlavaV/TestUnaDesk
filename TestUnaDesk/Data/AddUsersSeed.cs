using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;
using Role = Volo.Abp.Identity.IdentityRole;
using User = Volo.Abp.Identity.IdentityUser;

namespace TestUnaDesk.Data
{
    public class AddUsersSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly IdentityRoleManager _roleManager;

        public AddUsersSeed(
            IdentityUserManager identityUserManager,
             ICurrentTenant currentTenant,
             IdentityRoleManager roleManager
            )
        {
            _identityUserManager = identityUserManager;
            _currentTenant = currentTenant;
            _roleManager = roleManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                var rootRole = new Role(Guid.NewGuid(), "Root", context?.TenantId);
                var noRootRole = new Role(Guid.NewGuid(), "NoRoot", context?.TenantId);
                if (!await _roleManager.RoleExistsAsync(rootRole.Name))
                    await _roleManager.CreateAsync(rootRole);
                if (!await _roleManager.RoleExistsAsync(noRootRole.Name))
                    await _roleManager.CreateAsync(noRootRole);

                var superUser = new User(Guid.NewGuid(), "superUser", "superUser@Krypton.kr", context?.TenantId);
                var dublicateUser = await _identityUserManager.FindByEmailAsync(superUser.Email);
                if (dublicateUser != null)
                {
                    await _identityUserManager.CreateAsync(superUser, "1Qaz@wsx");
                    await _identityUserManager.AddToRoleAsync(superUser, rootRole.Name);
                }
                var noSuperUser = new User(Guid.NewGuid(), "noSuperUser", "noSuperUser@Krypton.kr", context?.TenantId);
                dublicateUser = await _identityUserManager.FindByEmailAsync(noSuperUser.Email);
                if (dublicateUser != null)
                {
                    await _identityUserManager.CreateAsync(noSuperUser, "1Qaz@wsx");
                    await _identityUserManager.AddToRoleAsync(noSuperUser, noRootRole.Name);
                }
            }

        }
    }
}
