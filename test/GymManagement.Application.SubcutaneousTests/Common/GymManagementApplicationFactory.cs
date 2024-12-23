using GymManagement.Api;
using GymManagement.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application.SubcutaneousTests.Common;

public class GymManagementApplicationFactory : WebApplicationFactory<IAssemblyMarker>, IAsyncLifetime
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.Remove(services.Single(s => s.ServiceType == typeof(DbContextOptions<GymManagementDbContext>)));

            services.AddDbContext<GymManagementDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDbForTesting"), ServiceLifetime.Singleton);
        });
    }

    public IMediator CreateMediator()
    {
        var serviceScope = Services.CreateScope();
        return serviceScope.ServiceProvider.GetRequiredService<IMediator>();
    }
    
    public GymManagementDbContext CreateDbContext()
    {
        var serviceScope = Services.CreateScope();
        return serviceScope.ServiceProvider.GetRequiredService<GymManagementDbContext>();
    }

    public Task InitializeAsync() => Task.CompletedTask;
    public new Task DisposeAsync() => Task.CompletedTask;
}