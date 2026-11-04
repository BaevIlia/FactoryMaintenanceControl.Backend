using AutoMapper;
using WebBFF.Services.RestClients.Requests.Dto;
using WebBFF.Services.RestClients.Requests.Enums;

namespace WebBFF.Usecases.Queries;

[AutoMap(typeof(Request))]
public class RequestViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; }

    public RequestType Type { get; set; }

    public RequestPriority Priority { get; set; }

    public string ResponsibleName { get; set; }
}