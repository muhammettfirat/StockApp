using StockApp.Api.Core.Domain;
using StockApp.Api.Core.Helper;
using StockApp.Api.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace StockApp.Api.Infrastructure.Tools
{
    public class DataSeeder
    {
        private readonly StockAppContext _context;

        public DataSeeder(StockAppContext context)
        {
            _context = context;
        }

        public async void SeedData()
        {
            if (!_context.AppRoles.Any() )
            {
                var appRoleAdmin = new AppRole { Description=RoleTypeEnum.Admin };
                var appRoleMember = new AppRole { Description = RoleTypeEnum.Member };
             

                _context.AppRoles.AddRange(appRoleAdmin, appRoleMember);
             
                _context.SaveChanges();
            }
            if (!_context.AppRoles.Any() || !_context.AppUsers.Any())
            {
                var admin = await _context.AppRoles.FirstOrDefaultAsync(x => x.Description == RoleTypeEnum.Admin);
                var member = await _context.AppRoles.FirstOrDefaultAsync(x => x.Description == RoleTypeEnum.Member);
                var appUserAdmin = new AppUser { Name = "Admin ", UserName = "admin", Email = "admin@admin.com", Password = "1",AppRoleId= admin.Id };
                var appUserMember = new AppUser { Name = "Mehmet ", UserName = "mehmet", Email = "mehmet@mehmet.com", Password = "2", AppRoleId = member.Id };

        
                _context.AppUsers.AddRange(appUserAdmin, appUserMember);
                _context.SaveChanges();
            }
        }
    }
}
