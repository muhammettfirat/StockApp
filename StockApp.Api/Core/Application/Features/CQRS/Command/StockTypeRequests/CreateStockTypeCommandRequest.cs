using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests
{
    public class CreateStockTypeCommandRequest:IRequest
    {
        public string? Name { get; set; }
        public bool? Approval { get; set; }
    }
}
