using RequestsService.Domain.Dto;
using RequestsService.Domain.Entities;
using RequestsService.Domain.Enums;

namespace RequestsService.Domain.Repositories.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<RequestEntity>> GetListByUser(Guid userId);

    Task<RequestEntity> GetByUser(int requestId, Guid userId);

    Task CreateRequest(CreateRequestDto request);

    Task UpdateRequest(int requestId, Guid userId, string title, string description, RequestType type, RequestPriority priority);

    Task ChangeStatus(int requestId, Guid userId, RequestStatus status);

    Task DeleteRequest(int requestId, Guid userId);
}
