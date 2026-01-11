using AutoMapper;
using AutoMapper.Configuration.Annotations;
using RequestsService.Domain.Entities;
using RequestsService.Domain.Enums;

namespace RequestsService.Application.Usecases.Requests;

public class RequestListItemViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; }

    public string ResponsibleName { get; set; }
}

public class RequestListItemViewModelMapProfile : Profile
{
    public RequestListItemViewModelMapProfile()
    {
        CreateMap<RequestEntity, RequestListItemViewModel>()
            .ForMember(x => x.ResponsibleName, cfg => cfg.MapFrom(x => x.Responsible != null ? x.Responsible.FullName : string.Empty));
    }
}