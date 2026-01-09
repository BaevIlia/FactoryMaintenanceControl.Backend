using Microsoft.EntityFrameworkCore;
using RequestsService.Domain.Dto;
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

    public async Task<IEnumerable<RequestEntity>> GetListByUser(Guid userId)
    {
        var result = _context.Requests.Where(x => x.AuthorId == userId)
                                      .Include(x => x.Author)
                                      .Include(x => x.Responsible)
                                      .ToList();

        return result;
    }

    public async Task<RequestEntity> GetByUser(int requestId, Guid userId)
    {
        var result = _context.Requests.Where(x => x.Id == requestId && x.AuthorId == userId)
                                      .Include(x => x.Author)
                                      .Include(x => x.Responsible)
                                      .FirstOrDefault();

        if (result == null)
            throw new BadHttpRequestException("Указанной заявки не существует");

        return result;
    }

    public async Task CreateRequest(CreateRequestDto request)
    {
        var newRequest = new RequestEntity
        {
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTime.Now,
            Type = request.Type,
            Priority = request.Priority,
            AuthorId = request.UserId,
        };

        _context.Requests.Add(newRequest);

        _context.SaveChanges();
    }

    public async Task UpdateRequest()
    {
        throw new NotImplementedException(); 
    }

    public async Task ChangeStatus()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRequest(int requestId, Guid userId)
    {
        var request = _context.Requests.Where(x => x.Id == requestId && x.AuthorId == userId).FirstOrDefault();

        if (request == null)
            throw new BadHttpRequestException("Указанная заявка отсутствует");

        _context.Requests.Remove(request);

        _context.SaveChanges();
    }
}