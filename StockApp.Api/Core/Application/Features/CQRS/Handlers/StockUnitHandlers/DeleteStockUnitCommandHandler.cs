using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockUnitRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockUnitHandlers
{
    public class DeleteStockUnitCommandHandler : IRequestHandler<DeleteStockUnitCommandRequest>
    {
        private readonly IRepository<StockUnit> _repository;

        public DeleteStockUnitCommandHandler(IRepository<StockUnit> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteStockUnitCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
