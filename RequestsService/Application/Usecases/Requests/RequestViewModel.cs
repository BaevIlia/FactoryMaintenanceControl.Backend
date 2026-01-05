using AutoMapper;
using RequestsService.Domain.Entities;
using RequestsService.Domain.Enums;

namespace RequestsService.Application.Usecases.Requests;

[AutoMap(typeof(RequestEntity))]
public class RequestViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; }
}