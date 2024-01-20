using StockApp.Api.Core.Application.Dto;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests
{
    public class GetAllStockTypesQueryRequest : IRequest<List<StockTypeDto>>
    {
    }
}
