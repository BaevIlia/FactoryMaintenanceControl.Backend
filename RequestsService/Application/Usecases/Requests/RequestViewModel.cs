using AutoMapper;
using RequestsService.Domain.Entities;

namespace RequestsService.Application.Usecases.Requests;

[AutoMap(typeof(RequestEntity))]
public class RequestViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}