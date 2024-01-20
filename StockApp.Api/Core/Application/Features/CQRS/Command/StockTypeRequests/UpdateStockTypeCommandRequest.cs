using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests
{
    public class UpdateStockTypeCommandRequest:IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? Approval { get; set; }
    }
}
