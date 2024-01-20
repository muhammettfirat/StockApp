using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockTypeHandlers
{
    public class DeleteStockTypeCommandHandler : IRequestHandler<DeleteStockTypeCommandRequest>
    {
        private readonly IRepository<StockType> _repository;

        public DeleteStockTypeCommandHandler(IRepository<StockType> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
