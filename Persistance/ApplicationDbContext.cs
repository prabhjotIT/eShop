using Application.Data;
using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext    
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }
    public DbSet<Customer> Customers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DbSet<Order> Orders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();//configured the provider here at Onconfig method ie provider is PostgreSQl
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

