using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Domain
{
    public class AppRole: TrackedAggregateRoot<Guid>
    {

        public RoleTypeEnum? Description { get; set; }
        public List<AppUser>? AppUsers { get; set; }
        
       
    }
}
