using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public DeleteAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
