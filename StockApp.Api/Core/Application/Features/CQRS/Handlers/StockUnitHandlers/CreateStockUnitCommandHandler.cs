using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockUnitRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using StockApp.Api.Persistance.ExceptionHandling;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockUnitHandlers
{
    public class CreateStockUnitCommandHandler : IRequestHandler<CreateStockUnitCommandRequest>
    {
        private readonly IRepository<StockUnit> _repository;
        private readonly IMapper _mapper;
        public CreateStockUnitCommandHandler(IRepository<StockUnit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateStockUnitCommandRequest request, CancellationToken cancellationToken)
        {
           await Validation(request);
            await _repository.CreateAsync(new StockUnit
            {

                Code = request.Code,
                Description = request.Description,
                Type = request.Type,
                StockTypeId = request.StockTypeId,
                BuyingPrice = request.BuyingPrice,
                BuyingCurrency = request.BuyingCurrency,
                SellingPrice = request.SellingPrice,
                SellingCurrency = request.SellingCurrency,
                PaperWeight = request.PaperWeight,
                Approval = request.Approval,
            });
            return Unit.Value;
        }
        public async Task Validation(CreateStockUnitCommandRequest request)
        {
            if (request.Code == null)
                throw new SomeException("An error occurred...");
        }
    }
}
