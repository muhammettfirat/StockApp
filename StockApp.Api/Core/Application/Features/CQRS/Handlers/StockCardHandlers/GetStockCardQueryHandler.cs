using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockCardRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockCardHandlers
{
    public class GetStockCardQueryHandler : IRequestHandler<GetStockCardQueryRequest, StockCardDto>
    {
        private readonly IRepository<StockCard> _repository;
        private readonly IMapper _mapper;
        public GetStockCardQueryHandler(IRepository<StockCard> repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }


        public async Task<StockCardDto> Handle(GetStockCardQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<StockCard, StockCardDto>(data);
        }
    }
}
