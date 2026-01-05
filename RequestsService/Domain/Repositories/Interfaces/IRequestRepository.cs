using RequestsService.Domain.Entities;

namespace RequestsService.Domain.Repositories.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<RequestEntity>> GetList();

    Task<IEnumerable<RequestEntity>> GetListByUser(Guid userId);
}
