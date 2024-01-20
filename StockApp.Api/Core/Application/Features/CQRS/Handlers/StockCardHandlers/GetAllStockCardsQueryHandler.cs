using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockCardRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockCardHandlers
{
    public class GetAllStockCardsQueryHandler : IRequestHandler<GetAllStockCardsQueryRequest, List<StockCardDto>>
    {
        private readonly IRepository<StockCard> _repository;
        private readonly IMapper _mapper;
        public GetAllStockCardsQueryHandler(IRepository<StockCard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<StockCardDto>> Handle(GetAllStockCardsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<StockCard>, List<StockCardDto>>(data);
        }
    }
}
