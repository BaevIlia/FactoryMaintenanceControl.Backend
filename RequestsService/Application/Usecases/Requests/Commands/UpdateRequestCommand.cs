using MediatR;
using RequestsService.Domain.Enums;
using RequestsService.Domain.Repositories.Interfaces;
using System.Text.Json.Serialization;

namespace RequestsService.Application.Usecases.Requests.Commands;

public class UpdateRequestCommand : IRequest
{
    [JsonIgnore]
    public int RequestId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public RequestType Type { get; set; }

    public RequestPriority Priority { get; set; }

    public UpdateRequestCommand(int requestId, string title, string description, RequestType type, RequestPriority priority)
    {
        RequestId = requestId;
        Title = title;
        Description = description;
        Type = type;
        Priority = priority;
    }

    private class Handler : IRequestHandler<UpdateRequestCommand>
    {
        private readonly IRequestRepository _repository;

        public Handler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse("c5209f70-7106-4166-b1c1-36a07693129f");

            await _repository.UpdateRequest(request.RequestId, userId, request.Title, request.Description, request.Type, request.Priority);
        }
    }
}