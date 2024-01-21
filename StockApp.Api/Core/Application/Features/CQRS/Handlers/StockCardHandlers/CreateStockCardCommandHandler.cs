using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using StockApp.Api.Persistance.ExceptionHandling;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockCardHandlers
{
    public class CreateStockCardCommandHandler : IRequestHandler<CreateStockCardCommandRequest>
    {
        private readonly IRepository<StockCard> _repository;
        private readonly IMapper _mapper;
        public CreateStockCardCommandHandler(IRepository<StockCard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateStockCardCommandRequest request, CancellationToken cancellationToken)
        {
            await Validation(request);
            await _repository.CreateAsync(new StockCard
            {

                Code = request.Code,
                ProductType = request.ProductType,
                Description = request.Description,
                StockTypeId = request.StockTypeId,
                StockUnitId = request.StockUnitId,
                ShelfInformation = request.ShelfInformation,
                CabinetInformation = request.CabinetInformation,
                Amount = request.Amount,
                CriticalQuantity = request.CriticalQuantity
            });
            return Unit.Value;
        }
        public async Task Validation(CreateStockCardCommandRequest request)
        {
            if(request.Code==null)
            throw new SomeException("An error occurred...");
        }
    }
}
