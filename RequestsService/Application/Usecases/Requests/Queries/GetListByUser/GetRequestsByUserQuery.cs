using AutoMapper;
using MediatR;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Queries.GetByUser;

public class GetRequestsByUserQuery : IRequest<IEnumerable<RequestViewModel>>
{
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
            //TODO: Переделать на получение Id из аутентификации
            var mockUserId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");
            var result = await _repository.GetListByUser(mockUserId);

            return _mapper.Map<IEnumerable<RequestViewModel>>(result);
        }
    }
}