using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public UpdateAppUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var existingAppUser = await _repository.GetByIdAsync(request.Id);

            if (existingAppUser != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingAppUser.Name = request.Name;
                existingAppUser.UserName = request.UserName;
                existingAppUser.Email = request.Email;
                existingAppUser.Password = request.Password;
                existingAppUser.AppRoleId = request.AppRoleId;

                await _repository.UpdateAsync(existingAppUser);
            }
            // Eğer belirtilen id'ye sahip bir varlık bulunamazsa, isteğe bağlı olarak bir hata fırlatılabilir.
            else
            {
                throw new InvalidOperationException($"AppUser with id {request.Id} not found.");
            }

            return Unit.Value;
        }
    }
}
