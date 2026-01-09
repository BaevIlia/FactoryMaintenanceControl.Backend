using AutoMapper;
using MediatR;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Queries.GetByUser;

public class GetRequestByUserQuery(int requestId) : IRequest<RequestViewModel>
{
    public int RequestId { get; } = requestId;

    private class Handler : IRequestHandler<GetRequestByUserQuery, RequestViewModel>
    {
        private readonly IRequestRepository _repository;
        private readonly IMapper _mapper;

        public Handler(IRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestViewModel> Handle(GetRequestByUserQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");

            var result = _mapper.Map<RequestViewModel>(await _repository.GetByUser(request.RequestId, userId));

            return result;
        }
    }
}