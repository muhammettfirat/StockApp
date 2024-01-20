using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests
{
    public class DeleteStockCardCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteStockCardCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
