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

            var existingGuideBook = await _repository.GetByIdAsync(request.Id);

            if (existingGuideBook != null)
            {
                // Varlık bulundu, güncelleme işlemi yapılır
                existingGuideBook.Code = request.Code;
                existingGuideBook.Description = request.Description;
                existingGuideBook.Type = request.Type;
                existingGuideBook.StockTypeId = request.StockTypeId;
                existingGuideBook.BuyingPrice = request.BuyingPrice;
                existingGuideBook.BuyingCurrency = request.BuyingCurrency;
                existingGuideBook.SellingPrice = request.SellingPrice;
                existingGuideBook.SellingCurrency = request.SellingCurrency;
                existingGuideBook.PaperWeight = request.PaperWeight;
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
