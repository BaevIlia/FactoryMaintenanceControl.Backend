using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestsService.Domain.Enums;

namespace RequestsService.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public JobTitle JobTitle { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(new UserEntity { Id = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f"), FullName = "Иванов Иван Иванович", JobTitle = JobTitle.Engineer, Email = "engineer@job.ru", Phone = "+79999999999" },
            new UserEntity { Id = Guid.Parse("f4c3952d-d633-4850-9042-8af385ef2253"), FullName = "Петров Петр Петрович", JobTitle = JobTitle.Manager, Email = "manager@job.ru", Phone = "+78888888888" });
    }
}