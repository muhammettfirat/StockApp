namespace StockApp.Api.Core.Application.Dto
{
    public class CheckUserResponseDto
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public bool? IsExist { get; set; }
    }
}
