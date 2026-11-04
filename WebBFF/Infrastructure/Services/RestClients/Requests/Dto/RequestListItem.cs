using WebBFF.Services.RestClients.Requests.Enums;

namespace WebBFF.Services.RestClients.Requests.Dto;

public record RequestListItem(int id, string title, DateTime createdAt, RequestStatus status, string responsibleName);