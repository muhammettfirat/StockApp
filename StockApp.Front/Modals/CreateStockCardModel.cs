using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Front.Modals.Helper;

namespace StockApp.Front.Modals
{
    public class CreateStockCardModel
    {
        public string? Code { get; set; }
        public ProductTypeEnum? ProductType { get; set; }
        public string? Description { get; set; }
        public string? StockTypeId { get; set; }
        public List<SelectListItem>? StockTypeList { get; set; }
        public string? StockUnitId { get; set; }
        public List<SelectListItem>? StockUnitList { get; set; }
        public string? ShelfInformation { get; set; }
        public string? CabinetInformation { get; set; }
        public decimal? Amount { get; set; }
        public decimal? CriticalQuantity { get; set; }
    }
}
