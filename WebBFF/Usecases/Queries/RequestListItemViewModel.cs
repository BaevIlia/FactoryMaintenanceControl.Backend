using AutoMapper;
using WebBFF.Services.RestClients.Requests.Dto;
using WebBFF.Services.RestClients.Requests.Enums;

namespace WebBFF.Usecases.Queries;

[AutoMap(typeof(RequestListItem))]
public class RequestListItemViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; }

    public string ResponsibleName { get; set; }
}