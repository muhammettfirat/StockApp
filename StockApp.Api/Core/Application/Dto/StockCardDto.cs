using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Application.Dto
{
    public class StockCardDto
    {
        public Guid? Id { get; set; }
        public string? Code { get; set; }
        public ProductTypeEnum? ProductType { get; set; }
        public string? Description { get; set; }
        public string? StockTypeId { get; set; }
        public string? StockUnitId { get; set; }
        public string? ShelfInformation { get; set; }
        public string? CabinetInformation { get; set; }
        public decimal? Amount { get; set; }
        public decimal? CriticalQuantity { get; set; }
    }
}
