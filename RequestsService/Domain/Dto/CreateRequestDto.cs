using RequestsService.Domain.Enums;

namespace RequestsService.Domain.Dto;

public class CreateRequestDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public RequestType Type { get; set; }

    public RequestPriority Priority { get; set; }

    public Guid UserId { get; set; }
} 