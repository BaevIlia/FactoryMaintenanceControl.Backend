using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RequestsService.Domain.Entities;

public class Request
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}

public class RequestEntityConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(
            new Request { Id = 1, Title = "Тестовая заявка 1", Description = "Тестовое описание 1" },
            new Request { Id = 2, Title = "Тестовая заявка 2", Description = "Тестовое описание 2"}
            );
    }
}