using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RequestsService.Domain.Entities;

public class RequestEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}

public class RequestEntityConfiguration : IEntityTypeConfiguration<RequestEntity>
{
    public void Configure(EntityTypeBuilder<RequestEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(
            new RequestEntity { Id = 1, Title = "Тестовая заявка 1", Description = "Тестовое описание 1" },
            new RequestEntity { Id = 2, Title = "Тестовая заявка 2", Description = "Тестовое описание 2"}
            );
    }
}