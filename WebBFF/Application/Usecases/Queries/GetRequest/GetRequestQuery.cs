using MediatR;
using System.Text.Json.Serialization;
using WebBFF.Services.Requests;

namespace WebBFF.Usecases.Queries.GetRequest;

public class GetRequestQuery(int id) : IRequest<RequestViewModel>
{
    [JsonIgnore]
    public int Id { get; } = id;

    private class Handler : IRequestHandler<GetRequestQuery, RequestViewModel>
    {
        private readonly IRequestsService _service;

        public Handler(IRequestsService service)
        {
            _service = service;
        }

        public Task<RequestViewModel> Handle(GetRequestQuery request, CancellationToken cancellationToken)
        {
            return _service.GetRequest(request.Id);
        }
    }
}