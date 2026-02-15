using AutoMapper;
using RequestsService.Domain.Entities;
using RequestsService.Domain.Enums;

namespace RequestsService.Application.Usecases.Requests;

public class RequestViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public RequestStatus Status { get; set; }

    public RequestType Type {  get; set; }

    public RequestPriority Priority { get; set; }

    public string ResponsibleName { get; set;}

    public string AuthorName { get; set;}
}

public class RequestViewModelMapProfile : Profile
{
    public RequestViewModelMapProfile()
    {
        CreateMap<RequestEntity, RequestViewModel>()
            .ForMember(x => x.AuthorName, cfg => cfg.MapFrom(x=>x.Author != null ? x.Author.FullName : string.Empty))
            .ForMember(x => x.ResponsibleName, cfg => cfg.MapFrom(x => x.Responsible != null ? x.Responsible.FullName : string.Empty));
    }
}