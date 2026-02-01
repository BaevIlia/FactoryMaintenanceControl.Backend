using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure;

public class AuthDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AuthDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("AuthDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}