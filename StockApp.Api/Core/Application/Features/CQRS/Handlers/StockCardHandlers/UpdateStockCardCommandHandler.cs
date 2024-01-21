using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using StockApp.Api.Persistance.ExceptionHandling;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockCardHandlers
{
    public class UpdateStockCardCommandHandler : IRequestHandler<UpdateStockCardCommandRequest>
    {
        private readonly IRepository<StockCard> _repository;
        private readonly IMapper _mapper;
        public UpdateStockCardCommandHandler(IRepository<StockCard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStockCardCommandRequest request, CancellationToken cancellationToken)
        {

            var existingGuideBook = await _repository.GetByIdAsync(request.Id);

            if (existingGuideBook != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingGuideBook.Code = request.Code;
                existingGuideBook.ProductType = request.ProductType;
                existingGuideBook.Description = request.Description;
                existingGuideBook.StockTypeId = request.StockTypeId;
                existingGuideBook.StockUnitId = request.StockUnitId;
                existingGuideBook.ShelfInformation = request.ShelfInformation;
                existingGuideBook.CabinetInformation = request.CabinetInformation;
                existingGuideBook.Amount = request.Amount;
                existingGuideBook.CriticalQuantity = request.CriticalQuantity;


                await _repository.UpdateAsync(existingGuideBook);
            }
            // Eğer belirtilen id'ye sahip bir varlık bulunamazsa, isteğe bağlı olarak bir hata fırlatılabilir.
            else
            {
                throw new InvalidOperationException($"StockCard with id {request.Id} not found.");
            }

            return Unit.Value;
        }
    
    }
}
