using WebBFF.Usecases.Queries;

namespace WebBFF.Services.Requests;

public interface IRequestsService
{
    Task<RequestViewModel> GetRequest(int id);
}