using RequestsService.Domain.Enums;

namespace RequestsService.Application.Usecases.Requests;

public class RequestListItemViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; }

    public string ResponsibleName { get; set; }
}