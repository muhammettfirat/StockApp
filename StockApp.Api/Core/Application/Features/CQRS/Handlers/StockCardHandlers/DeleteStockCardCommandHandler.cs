using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockCardHandlers
{
    public class DeleteStockCardCommandHandler : IRequestHandler<DeleteStockCardCommandRequest>
    {
        private readonly IRepository<StockCard> _repository;

        public DeleteStockCardCommandHandler(IRepository<StockCard> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteStockCardCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
