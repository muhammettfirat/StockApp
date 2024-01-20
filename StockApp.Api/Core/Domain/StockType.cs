using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Domain
{
    public class StockType: TrackedAggregateRoot<Guid>
    {
        public string? Name { get; set; }
        public bool? Approval { get; set; }
    }
}
