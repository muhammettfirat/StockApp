using AutoMapper;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppRoleHandlers
{
    public class CreateAppRoleCommandHandler : IRequestHandler<CreateAppRoleCommandRequest>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;
        public CreateAppRoleCommandHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppRole
            {
                Description = request.Description
            });
            return Unit.Value;
        }
    }
}
