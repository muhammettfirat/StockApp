using MediatR;
using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockUnitRequests
{
    public class UpdateStockUnitCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public StockUnitEnum? Type { get; set; }
        public string? StockTypeId { get; set; }
        public decimal? BuyingPrice { get; set; }
        public CurrencyEnum? BuyingCurrency { get; set; }
        public decimal? SellingPrice { get; set; }
        public CurrencyEnum? SellingCurrency { get; set; }
        public decimal? PaperWeight { get; set; }
        public bool? Approval { get; set; }
    }
}
