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

            var existingStockCard = await _repository.GetByIdAsync(request.Id);

            if (existingStockCard != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingStockCard.Code = request.Code;
                existingStockCard.ProductType = request.ProductType;
                existingStockCard.Description = request.Description;
                existingStockCard.StockTypeId = request.StockTypeId;
                existingStockCard.StockUnitId = request.StockUnitId;
                existingStockCard.ShelfInformation = request.ShelfInformation;
                existingStockCard.CabinetInformation = request.CabinetInformation;
                existingStockCard.Amount = request.Amount;
                existingStockCard.CriticalQuantity = request.CriticalQuantity;


                await _repository.UpdateAsync(existingStockCard);
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
