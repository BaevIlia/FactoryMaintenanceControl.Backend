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

    public RequestPriority Priority { get; set; }

    public RequestType Type { get; set; }

    public Guid AuthorId { get; set; }

    public Guid? ResponsibleId { get; set; }

    public UserEntity Author { get; set; }

    public UserEntity? Responsible { get; set; }
}

public class RequestEntityConfiguration : IEntityTypeConfiguration<RequestEntity>
{
    public void Configure(EntityTypeBuilder<RequestEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.HasIndex(x => new { x.Id, x.AuthorId });

        builder.HasOne(a => a.Author)
               .WithMany(r => r.CreatedRequests)
               .HasForeignKey(a => a.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Responsible)
               .WithMany(r => r.ResponsibleRequests)
               .HasForeignKey(r => r.ResponsibleId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}