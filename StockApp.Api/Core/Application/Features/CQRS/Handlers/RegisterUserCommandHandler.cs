using StockApp.Api.Core.Application.Features.CQRS.Command;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using StockApp.Api.Core.Helper;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> repository;
        private readonly IRepository<AppRole> _roleRepository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository, IRepository<AppRole> roleRepository)
        {
            this.repository = repository;
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            
            await this.repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.Username,
                AppRoleId = request.RoleId
            });

            return Unit.Value;
        }
    }
}
