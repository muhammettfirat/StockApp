using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Dto
{
    public class AppUserDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? AppRoleId { get; set; }
        public AppRoleDto? AppRole { get; set; }
       
    }
}
