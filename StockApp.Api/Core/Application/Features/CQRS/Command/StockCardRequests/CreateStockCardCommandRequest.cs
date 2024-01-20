﻿using MediatR;
using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests
{
    public class CreateStockCardCommandRequest : IRequest
    {
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
