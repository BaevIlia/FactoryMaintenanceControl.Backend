using AuthService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public JobTitle Title { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool IsDeleted { get; set; } = false;
}

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(new User
        {
            Id = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f"),
            Email = "engineer@job.ru",
            PhoneNumber = "+79999999999",
            Title = JobTitle.Engineer,
            RegistrationDate = new DateTime(2026, 02, 01),
        });
    }
}