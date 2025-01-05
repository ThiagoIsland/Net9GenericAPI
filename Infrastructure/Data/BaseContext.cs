using Microsoft.EntityFrameworkCore;
using GenericAPI.Core.Entities;
namespace GenericAPI.Infrastructure.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Pessoa>()
            .ToTable("Pessoas")
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Pessoa>()
            .Property(u => u.CreatedAt)
            .ValueGeneratedOnAdd()
            .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

    }
   public DbSet<Pessoa> Pessoas { get; set; }
}