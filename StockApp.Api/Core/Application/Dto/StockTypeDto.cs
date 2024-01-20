namespace StockApp.Api.Core.Application.Dto
{
    public class StockTypeDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public bool? Approval { get; set; }
    }
}
