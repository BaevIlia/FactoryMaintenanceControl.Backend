using AutoMapper;
using MediatR;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Queries;

public class GetRequestsQuery : IRequest<IEnumerable<RequestViewModel>>
{
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
            var requests = _mapper.Map<IEnumerable<RequestViewModel>>(await _repository.GetList());

            return requests;
        }
    }
}