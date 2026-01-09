using AutoMapper;
using MediatR;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Queries;

public class GetRequestsQuery : IRequest<IEnumerable<RequestViewModel>>
{
    public int RequestId { get; set; }

    private class Handler : IRequestHandler<GetRequestsQuery, IEnumerable<RequestViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _repository;

        public Handler(IMapper mapper, IRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<RequestViewModel>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");
            var requests = _mapper.Map<IEnumerable<RequestViewModel>>(await _repository.GetByUser(request.RequestId, userId));

            return requests;
        }
    }
}