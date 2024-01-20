using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockTypeHandlers
{
    public class GetAllStockTypesQueryHandler : IRequestHandler<GetAllStockTypesQueryRequest, List<StockTypeDto>>
    {
        private readonly IRepository<StockType> _repository;
        private readonly IMapper _mapper;
        public GetAllStockTypesQueryHandler(IRepository<StockType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<StockTypeDto>> Handle(GetAllStockTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<StockType>, List<StockTypeDto>>(data);
        }
    }
}
