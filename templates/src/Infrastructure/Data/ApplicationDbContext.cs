using System.Reflection;
using Hupo.Template.Application.Common.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hupo.Template.Infrastructure.Data;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>,
      IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // builder.Entity<IdentityUserClaim<long>>().HasNoKey().Ignore(x => x.Id);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
