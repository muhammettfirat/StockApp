using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests
{
    public class DeleteStockTypeCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteStockTypeCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
