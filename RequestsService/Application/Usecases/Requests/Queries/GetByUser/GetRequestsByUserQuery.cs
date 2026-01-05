using AutoMapper;
using MediatR;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Queries.GetByUser;

public class GetRequestsByUserQuery : IRequest<IEnumerable<RequestViewModel>>
{
    public Guid UserId { get; set; }

    public GetRequestsByUserQuery(Guid userId)
    {
        UserId = userId;
    }

    private class Handler : IRequestHandler<GetRequestsByUserQuery, IEnumerable<RequestViewModel>>
    {
        private readonly IRequestRepository _repository;
        private readonly IMapper _mapper;

        public Handler(IRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RequestViewModel>> Handle(GetRequestsByUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetListByUser(request.UserId);

            return _mapper.Map<IEnumerable<RequestViewModel>>(result);
        }
    }
}