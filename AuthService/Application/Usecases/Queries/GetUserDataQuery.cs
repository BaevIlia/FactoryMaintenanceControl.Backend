using System.Security.Claims;
using AuthService.Domain.Repositories.Interfaces;

using MediatR;

namespace AuthService.Application.Usecases.Queries;

public class GetUserDataQuery(Guid userId) : IRequest<UserDataViewModel>
{
    public Guid UserId { get; set; } = userId;
    
    private class Handler : IRequestHandler<GetUserDataQuery, UserDataViewModel>
    {
        private readonly IUserRepository  _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDataViewModel> Handle(GetUserDataQuery request, CancellationToken cancellationToken = default)
        {
            var userData = await _userRepository.GetById(request.UserId, cancellationToken);
            
            return new(userData.Id, userData.Email, userData.FullName, userData.Title);
        }
    }
}