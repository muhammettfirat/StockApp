using AutoMapper;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppRoleHandlers
{
    public class UpdateAppRoleCommandHandler : IRequestHandler<UpdateAppRoleCommandRequest>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;
        public UpdateAppRoleCommandHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var existingAppRole = await _repository.GetByIdAsync(request.Id);

            if (existingAppRole != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingAppRole.Description = request.Description;

                await _repository.UpdateAsync(existingAppRole);
            }
            // Eğer belirtilen id'ye sahip bir varlık bulunamazsa, isteğe bağlı olarak bir hata fırlatılabilir.
            else
            {
                throw new InvalidOperationException($"AppRole with id {request.Id} not found.");
            }

            return Unit.Value;
        }
    }
}
