using MediatR;
using RequestsService.Domain.Dto;
using RequestsService.Domain.Enums;
using RequestsService.Domain.Repositories.Interfaces;

namespace RequestsService.Application.Usecases.Requests.Commands;

public class CreateRequestCommand : IRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public RequestType Type { get; set; }

    public RequestPriority Priority { get; set; }

    private class Handler : IRequestHandler<CreateRequestCommand>
    {
        private readonly IRequestRepository _repository;

        public Handler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");
            var newRequest = new CreateRequestDto
            {
                Title = request.Title,
                Description = request.Description,
                Type = request.Type,
                Priority = request.Priority,
                UserId = userId,
            };

            await _repository.CreateRequest(newRequest);
        }
    }
}