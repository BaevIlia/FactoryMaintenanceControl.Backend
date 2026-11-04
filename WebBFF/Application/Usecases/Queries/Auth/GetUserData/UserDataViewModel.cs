using AutoMapper;
using WebBFF.Domain.Dtos;
using WebBFF.Infrastructure.Services.RestClients.Auth.Enums;

namespace WebBFF.Usecases.Queries.Auth.GetUserData;

[AutoMap(typeof(UserData), ReverseMap = true)]
public record UserDataViewModel(Guid UserId, string Email, string FullName, JobTitle Title);