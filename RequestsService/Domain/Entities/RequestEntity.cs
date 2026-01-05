using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestsService.Domain.Enums;

namespace RequestsService.Domain.Entities;

public class RequestEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; } = RequestStatus.Created;

    public Guid AuthorId { get; set; }

    public Guid ManagerId { get; set; }
}

public class RequestEntityConfiguration : IEntityTypeConfiguration<RequestEntity>
{
    public void Configure(EntityTypeBuilder<RequestEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(
            new RequestEntity { 
                Id = 1, 
                Title = "Тестовая заявка 1", 
                Description = "Тестовое описание 1",  
                CreatedAt = new DateTime(2026, 1, 5, 12, 0, 0), 
                Status = RequestStatus.Created, 
                AuthorId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f") },
            new RequestEntity { 
                Id = 2, 
                Title = "Тестовая заявка 2", 
                Description = "Тестовое описание 2", 
                CreatedAt = new DateTime(2026, 1, 3, 14, 0, 0), 
                Status = RequestStatus.Completed, 
                AuthorId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f"), 
                ManagerId = Guid.Parse("f4c3952d-d633-4850-9042-8af385ef2253") }
            );
    }
}