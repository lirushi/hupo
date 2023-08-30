using Hupo.Template.Infrastructure.Data;
using Hupo.Template.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region identity
        services
            .AddIdentityCore<ApplicationUser>(opts =>
            {
                configuration.GetSection("Identity").Bind(opts);
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        #endregion

        #region entity framework
        services.AddScoped<ISaveChangesInterceptor, CreateAuditableInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, ModifyAuditableInterceptors>();
        services.AddScoped<ISaveChangesInterceptor, DeleteAuditableInterceptor>();

        var connectionString = configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("missing default connection config");
        services.AddDbContext<ApplicationDbContext>(
            (sp, opts) =>
            {
                opts.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
#if UseSQLite
                opts.UseSqlite(connectionString);
#else
                opts.UseNpgsql(connectionString);
#endif
                if (sp.GetRequiredService<IHostEnvironment>().IsDevelopment()) {
                    opts.UseLoggerFactory(sp.GetRequiredService<ILoggerFactory>()).EnableSensitiveDataLogging().EnableDetailedErrors();
                }

                opts.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            }
        );
        #endregion
    }
}
