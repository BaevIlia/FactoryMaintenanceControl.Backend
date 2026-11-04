using AutoMapper;
using MediatR;
using WebBFF.Infrastructure.Services.Auth;
using WebBFF.Infrastructure.Services.User;

namespace WebBFF.Usecases.Queries.Auth.GetUserData;

public class GetUserDataQuery : IRequest<UserDataViewModel>
{
    private class Handler : IRequestHandler<GetUserDataQuery, UserDataViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public Handler(IMapper mapper, IAuthService authService, IUserService userService)
        {
            _mapper = mapper;
            _authService = authService;
            _userService = userService;
        }

        public async Task<UserDataViewModel> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            var userId = await _userService.GetUserId(cancellationToken);
            
            var res = await _authService.GetUserData(userId, cancellationToken);
            return _mapper.Map<UserDataViewModel>(res);
        }
    }
}