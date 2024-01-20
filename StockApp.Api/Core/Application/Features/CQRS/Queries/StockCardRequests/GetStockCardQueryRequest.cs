using MediatR;
using StockApp.Api.Core.Application.Dto;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.StockCardRequests
{
    public class GetStockCardQueryRequest : IRequest<StockCardDto>
    {
        public Guid Id { get; set; }
        public GetStockCardQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
