using AutoMapper;
using MediatR;
using WebBFF.Services.Requests;

namespace WebBFF.Usecases.Queries.GetRequests;

public class GetRequestsQuery : IRequest<RequestListItemViewModel[]>
{
    private class Handler : IRequestHandler<GetRequestsQuery, RequestListItemViewModel[]>
    {
        private readonly IRequestsService _service;

        public Handler(IRequestsService service)
        {
            _service = service;
        }

        public async Task<RequestListItemViewModel[]> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetRequests();

            return result;
        }
    }
}