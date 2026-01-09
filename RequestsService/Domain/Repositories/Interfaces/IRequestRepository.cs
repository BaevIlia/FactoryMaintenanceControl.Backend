using RequestsService.Domain.Dto;
using RequestsService.Domain.Entities;

namespace RequestsService.Domain.Repositories.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<RequestEntity>> GetListByUser(Guid userId);

    Task<RequestEntity> GetByUser(int requestId, Guid userId);

    Task CreateRequest(CreateRequestDto request);

    Task UpdateRequest();

    Task ChangeStatus();

    Task DeleteRequest(int requestId, Guid userId);
}
