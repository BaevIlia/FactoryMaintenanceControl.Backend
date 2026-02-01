using WebBFF.Services.RestClients.Requests.Dto;
using WebBFF.Usecases.Queries;

namespace WebBFF.Services.Requests;

public interface IRequestsService
{
    Task<RequestListItemViewModel[]> GetRequests();

    Task<RequestViewModel> GetRequest(int id);
}