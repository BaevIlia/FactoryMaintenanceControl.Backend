using MediatR;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Commands;

public class DeleteRequestCommand(int id) : IRequest
{
    public int Id { get; set; } = id;

    private class Handler : IRequestHandler<DeleteRequestCommand>
    {
        private readonly IRequestRepository _repository;

        public Handler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            //TODO: Переделать на получение id из токена
            var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");

            await _repository.DeleteRequest(request.Id, userId);        
        }
    }
}