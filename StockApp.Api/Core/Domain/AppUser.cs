using StockApp.Api.Core.Helper;

namespace StockApp.Api.Core.Domain
{
    public class AppUser: TrackedAggregateRoot<Guid>
    {
       
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? AppRoleId { get; set;}
        public AppRole? AppRole { get; set;}
       
    }
}
