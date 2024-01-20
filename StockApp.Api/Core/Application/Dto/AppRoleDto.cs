using StockApp.Api.Core.Domain;
using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Application.Dto
{
    public class AppRoleDto
    {
        public Guid? Id { get; set; }
        public RoleTypeEnum? Description { get; set; }
        public List<AppUserDto>? AppUsers { get; set; }
    }
   
}
