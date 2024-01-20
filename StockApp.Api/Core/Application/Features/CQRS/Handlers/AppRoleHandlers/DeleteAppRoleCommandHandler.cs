using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppRoleHandlers
{
    public class DeleteAppRoleCommandHandler : IRequestHandler<DeleteAppRoleCommandRequest>
    {
        private readonly IRepository<AppRole> _repository;

        public DeleteAppRoleCommandHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
