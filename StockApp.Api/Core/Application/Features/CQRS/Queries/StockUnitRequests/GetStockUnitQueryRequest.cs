using MediatR;
using StockApp.Api.Core.Application.Dto;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.StockUnitRequests
{
    public class GetStockUnitQueryRequest : IRequest<StockUnitDto>
    {
        public Guid Id { get; set; }
        public GetStockUnitQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
