using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests
{
    public class GetStockTypeQueryRequest:IRequest<StockTypeDto>
    {
        public Guid Id { get; set; }
        public GetStockTypeQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
