using Microsoft.EntityFrameworkCore;
using RequestsService.Domain.Entities;

namespace RequestsService.Infrastructure;

public class RequestDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public RequestDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<RequestEntity> Requests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("RequestsDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RequestEntityConfiguration());
    }
}