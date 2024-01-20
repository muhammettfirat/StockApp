using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockUnitRequests
{
    public class DeleteStockUnitCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteStockUnitCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
