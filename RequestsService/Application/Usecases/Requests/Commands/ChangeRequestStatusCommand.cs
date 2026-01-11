using MediatR;
using RequestsService.Domain.Enums;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Commands;

public class ChangeRequestStatusCommand(int requestId, RequestStatus status) : IRequest
{
    public int RequestId { get; set; } = requestId;

    public RequestStatus Status { get; set; } = status;

    private class Handler : IRequestHandler<ChangeRequestStatusCommand>
    {
        private readonly IRequestRepository _repository;

        public Handler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");

            await _repository.ChangeStatus(request.RequestId, userId, request.Status);
        }
    }
}