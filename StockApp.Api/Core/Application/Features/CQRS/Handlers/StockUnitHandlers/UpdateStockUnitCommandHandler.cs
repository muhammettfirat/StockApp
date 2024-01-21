using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockUnitRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockUnitHandlers
{
    public class UpdateStockUnitCommandHandler : IRequestHandler<UpdateStockUnitCommandRequest>
    {
        private readonly IRepository<StockUnit> _repository;
        private readonly IMapper _mapper;
        public UpdateStockUnitCommandHandler(IRepository<StockUnit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStockUnitCommandRequest request, CancellationToken cancellationToken)
        {

            var existingStockUnit = await _repository.GetByIdAsync(request.Id);

            if (existingStockUnit != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingStockUnit.Code = request.Code;
                existingStockUnit.Description = request.Description;
                existingStockUnit.Type = request.Type;
                existingStockUnit.StockTypeId = request.StockTypeId;
                existingStockUnit.BuyingPrice = request.BuyingPrice;
                existingStockUnit.BuyingCurrency = request.BuyingCurrency;
                existingStockUnit.SellingPrice = request.SellingPrice;
                existingStockUnit.SellingCurrency = request.SellingCurrency;
                existingStockUnit.PaperWeight = request.PaperWeight;
                existingStockUnit.Approval = request.Approval;


                await _repository.UpdateAsync(existingStockUnit);
            }
            // Eğer belirtilen id'ye sahip bir varlık bulunamazsa, isteğe bağlı olarak bir hata fırlatılabilir.
            else
            {
                throw new InvalidOperationException($"StockUnit with id {request.Id} not found.");
            }

            return Unit.Value;
        }
    }
}
