using Refit;
using WebBFF.Services.RestClients.Requests.Dto;

namespace WebBFF.Services.RestClients.Requests;

public interface IRequestServiceRestClient
{
    [Get("/requests/")]
    public Task<IEnumerable<RequestListItem>> GetList(Guid userId);

    [Get("/requests/{id}")]
    public Task<Request> Get(int id, Guid userId);
}