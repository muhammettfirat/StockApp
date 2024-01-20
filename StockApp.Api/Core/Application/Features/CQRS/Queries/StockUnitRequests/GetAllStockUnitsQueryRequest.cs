using MediatR;
using StockApp.Api.Core.Application.Dto;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.StockUnitRequests
{
    public class GetAllStockUnitsQueryRequest : IRequest<List<StockUnitDto>>
    {
    }
}
