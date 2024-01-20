using AutoMapper;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockTypeHandlers
{
    public class UpdateStockTypeCommandHandler : IRequestHandler<UpdateStockTypeCommandRequest>
    {
        private readonly IRepository<StockType> _repository;
        private readonly IMapper _mapper;
        public UpdateStockTypeCommandHandler(IRepository<StockType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStockTypeCommandRequest request, CancellationToken cancellationToken)
        {

            var existingGuideBook = await _repository.GetByIdAsync(request.Id);

            if (existingGuideBook != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingGuideBook.Name = request.Name;
                existingGuideBook.Approval = request.Approval;
             

                await _repository.UpdateAsync(existingGuideBook);
            }
            // Eğer belirtilen id'ye sahip bir varlık bulunamazsa, isteğe bağlı olarak bir hata fırlatılabilir.
            else
            {
                throw new InvalidOperationException($"StockType with id {request.Id} not found.");
            }

            return Unit.Value;
        }
    }
}
