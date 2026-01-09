using MediatR;

namespace RequestsService.Application.Usecases.Requests.Queries.GetByUser;

public class GetRequestByUserQuery : IRequest<RequestViewModel>
{
    private class Handler : IRequestHandler<GetRequestByUserQuery, RequestViewModel>
    {
        public Task<RequestViewModel> Handle(GetRequestByUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}