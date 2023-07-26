using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace TestUnaDesk.Data
{
    public class AddTenantSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly ITenantRepository _tenantRepository;
        private readonly ITenantManager _tenantManager;

        public AddTenantSeed(
            ICurrentTenant currentTenant,
            ITenantRepository tenantRepository,
            ITenantManager tenantManager)
        {
            _currentTenant = currentTenant;
            _tenantRepository = tenantRepository;
            _tenantManager = tenantManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context.TenantId))
            {
                var secondTenant = await _tenantManager.CreateAsync("secondTenant");//new CustomTenant(Guid.Parse("529A0B4F-C78E-43D3-87F2-EB55E0ECA556"), "secondTenant");
                secondTenant.SetConnectionString("anotherDb", "Host=localhost;Port=5432;Database=TestUnaDesk;User ID=postgres;Password=1Qaz@wsx;");
                //var tenants = new[] { new CustomTenant(Guid.Parse("F3846D90-7C4F-4F10-9A89-1E55DE75F643"), "fistTenant"), secondTenant };              
               
                try
                {

                    var dbontext = await _tenantRepository.InsertAsync(secondTenant,true);
                    
                    
                }
                catch(Exception ex) 
                {
                    throw;
                }
            }

        }

        private void Dbontext_SaveChangesFailed(object? sender, SaveChangesFailedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}