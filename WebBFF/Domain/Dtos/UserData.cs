using AutoMapper;
using WebBFF.Domain.Enums;
using WebBFF.Infrastructure.Services.RestClients.Auth.Responses;

namespace WebBFF.Domain.Dtos;

[AutoMap(typeof(UserDataResponse), ReverseMap = true)]
public class UserData
{
    public Guid UserId { get; set; }
    
    public string Email { get; set; }

    public string FullName { get; set; }

    public JobTitle Title { get; set; }
}