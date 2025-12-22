using Microsoft.EntityFrameworkCore;
using RequestsService.Domain.Entities;

namespace RequestsService.Infrastructure;

public class RequestsDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public RequestsDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    DbSet<Request> Requests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("RequestsDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RequestEntityConfiguration());
    }
}