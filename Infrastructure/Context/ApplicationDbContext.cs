using Domain;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext
    : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        ApplicationRoleClaim,
        IdentityUserToken<string>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    // Second Option
    //public DbSet<Employee> Employees = new DbSet<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity.Property(e => e.Salary).HasPrecision(18, 2);
        //});

        //foreach (var property in modelBuilder.Model.GetEntityTypes()
        //    .SelectMany(t => t.GetProperties())
        //    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        //{
        //    property.SetPrecision(18);
        //    property.SetScale(2);
        //}

        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18, 2)");
        }
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

    }
}