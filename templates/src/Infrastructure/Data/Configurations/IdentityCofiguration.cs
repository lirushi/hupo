using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hupo.Template.Infrastructure.Data.Configurations;

public class IdentityConfiguration
    : IEntityTypeConfiguration<ApplicationUser>,
      IEntityTypeConfiguration<ApplicationUserClaim>,
      IEntityTypeConfiguration<ApplicationUserLogin>,
      IEntityTypeConfiguration<ApplicationUserToken>,
      IEntityTypeConfiguration<ApplicationRole>,
      IEntityTypeConfiguration<ApplicationRoleClaim>,
      IEntityTypeConfiguration<ApplicationUserRole>
{
    private const string PREFIX = "Identity";
    private const string USER_TABLE_NAME = PREFIX + "Users";
    private const string USER_CLAIM_TABLE_NAME = PREFIX + "UserClaims";
    private const string USER_LOGIN_TABLE_NAME = PREFIX + "UserLogins";
    private const string USER_TOKEN_TABLE_NAME = PREFIX + "UserTokens";
    private const string ROLE_TABLE_NAME = PREFIX + "Roles";
    private const string ROLE_CLAIM_TABLE_NAME = PREFIX + "RoleClaims";
    private const string USER_ROLE_TABLE_NAME = PREFIX + "UserRoles";

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable(USER_TABLE_NAME);
        builder.ConfigureBaseEntity();
        builder.ConfigureCreateAuditable();
        builder.ConfigureModifyAuditable();
        builder.ConfigureDeleteAuditable();
        builder.ConfigureConcurrencyStamp();

        builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName($"UX_{USER_TABLE_NAME}_{nameof(ApplicationUser.NormalizedUserName)}").IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName($"IX_{USER_TABLE_NAME}_{nameof(ApplicationUser.NormalizedEmail)}");

        builder.Property(u => u.UserName).IsRequired().HasMaxLength(IdentityConst.User.MaxUserNameLength);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(IdentityConst.User.MaxUserNameLength);
        builder.Property(u => u.Email).HasMaxLength(IdentityConst.User.MaxEmailLength);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(IdentityConst.User.MaxEmailLength);
        builder.Property(u => u.SecurityStamp).IsRequired().HasMaxLength(IdentityConst.User.MaxSecurityStampLength);
        builder.Property(u => u.PasswordHash).HasMaxLength(IdentityConst.User.MaxPasswordHashLength);
        builder.Property(u => u.PhoneNumber).HasMaxLength(IdentityConst.User.MaxPhoneNumberLength);

        builder.HasMany(u => u.Claims).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId).IsRequired();
        builder.HasMany(u => u.Logins).WithOne(ul => ul.User).HasForeignKey(ul => ul.UserId).IsRequired();
        builder.HasMany(u => u.Tokens).WithOne(ut => ut.User).HasForeignKey(ut => ut.UserId).IsRequired();
        builder.HasMany(u => u.UserRoles).WithOne(ur => ur.User).HasForeignKey(ur => ur.UserId).IsRequired();
    }

    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder.ToTable(USER_CLAIM_TABLE_NAME);
        builder.ConfigureBaseEntity();

        builder.Property(x => x.ClaimType).HasMaxLength(IdentityConst.Calim.MaxTypeLength);
        builder.Property(x => x.ClaimValue).HasMaxLength(IdentityConst.Calim.MaxValueLength);
    }

    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        builder.ToTable(USER_LOGIN_TABLE_NAME);

        builder.HasKey(l => new {
            l.UserId,
            l.LoginProvider
        });

        builder.Property(l => l.LoginProvider).HasMaxLength(IdentityConst.UserLogin.MaxLoginProviderLength).IsRequired();
        builder.Property(l => l.ProviderKey).HasMaxLength(IdentityConst.UserLogin.MaxProviderKeyLength).IsRequired();
        builder.Property(l => l.ProviderDisplayName).HasMaxLength(IdentityConst.UserLogin.MaxProviderDisplayNameLength);
    }

    public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
    {
        builder.ToTable(USER_TOKEN_TABLE_NAME);
        builder.HasKey(t => new {
            t.UserId,
            t.LoginProvider,
            t.Name
        });

        builder.Property(t => t.LoginProvider).HasMaxLength(IdentityConst.UserLogin.MaxLoginProviderLength).IsRequired();
        builder.Property(t => t.Name).HasMaxLength(IdentityConst.UserLogin.MaxProviderKeyLength).IsRequired();
    }

    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable(ROLE_TABLE_NAME);
        builder.ConfigureBaseEntity();
        builder.ConfigureCreateAuditable();
        builder.ConfigureModifyAuditable();
        builder.ConfigureDeleteAuditable();
        builder.ConfigureConcurrencyStamp();

        builder.HasIndex(r => r.NormalizedName).HasDatabaseName($"UX_{ROLE_TABLE_NAME}_{nameof(ApplicationRole.NormalizedName)}").IsUnique();

        builder.Property(r => r.Name).IsRequired().HasMaxLength(IdentityConst.Role.MaxNameLength);
        builder.Property(r => r.NormalizedName).HasMaxLength(IdentityConst.Role.MaxNameLength);

        builder.HasMany(e => e.UserRoles).WithOne(e => e.Role).HasForeignKey(ur => ur.RoleId).IsRequired();
        builder.HasMany(e => e.Claims).WithOne(e => e.Role).HasForeignKey(rc => rc.RoleId).IsRequired();
    }

    public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {
        builder.ToTable(ROLE_CLAIM_TABLE_NAME);
        builder.ConfigureBaseEntity();

        builder.Property(x => x.ClaimType).HasMaxLength(IdentityConst.Calim.MaxTypeLength);
        builder.Property(x => x.ClaimValue).HasMaxLength(IdentityConst.Calim.MaxValueLength);
    }

    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.ToTable(USER_ROLE_TABLE_NAME);

        builder.HasKey(ur => new {
            ur.UserId,
            ur.RoleId
        });
    }
}
