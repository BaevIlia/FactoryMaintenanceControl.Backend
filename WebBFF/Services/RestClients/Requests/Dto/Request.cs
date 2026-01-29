using WebBFF.Services.RestClients.Requests.Enums;

namespace WebBFF.Services.RestClients.Requests.Dto;

public record Request(int id, string title, string desription, DateTime createdAt, RequestStatus status, RequestType type, RequestPriority priority, string responcibleName);