using AutoMapper;
using WebBFF.Services.RestClients.Requests;
using WebBFF.Usecases.Queries;

namespace WebBFF.Services.Requests;

public class RequestsService : IRequestsService
{
    private readonly IRequestServiceRestClient _restClient;
    private readonly IMapper _mapper;

    public RequestsService(IRequestServiceRestClient restClient, IMapper mapper)
    {
        _restClient = restClient;
        _mapper = mapper;
    }

    public async Task<RequestViewModel> GetRequest(int id)
    {
        var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");

        var res = await _restClient.Get(id, userId);

        return _mapper.Map<RequestViewModel>(res);
    }

    public async Task<RequestListItemViewModel[]> GetRequests()
    {
        var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");

        var res = await _restClient.GetList(userId);

        return _mapper.Map<RequestListItemViewModel[]>(res);
    }
}