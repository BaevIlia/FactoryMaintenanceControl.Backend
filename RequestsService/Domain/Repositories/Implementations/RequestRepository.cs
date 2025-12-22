using RequestsService.Domain.Entities;
using RequestsService.Domain.Repositories.Interfaces;
using RequestsService.Infrastructure;

namespace RequestsService.Domain.Repositories.Implementations;

public class RequestRepository : IRequestRepository
{
    private readonly RequestDbContext _context;

    public RequestRepository(RequestDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RequestEntity>> GetList()
    {
        var result = _context.Requests.ToList();

        return result;
    }
}