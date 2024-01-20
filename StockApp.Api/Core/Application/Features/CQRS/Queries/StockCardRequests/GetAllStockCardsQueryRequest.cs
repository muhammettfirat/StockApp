using MediatR;
using StockApp.Api.Core.Application.Dto;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.StockCardRequests
{
    public class GetAllStockCardsQueryRequest : IRequest<List<StockCardDto>>
    {
    }
}
