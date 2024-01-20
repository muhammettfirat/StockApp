using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public CreateAppUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {

                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                AppRoleId = request.AppRoleId
            });
            return Unit.Value;
        }
    }
}
