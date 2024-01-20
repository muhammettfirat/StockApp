using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockUnitRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockUnitHandlers
{
    public class GetAllStockUnitsQueryHandler : IRequestHandler<GetAllStockUnitsQueryRequest, List<StockUnitDto>>
    {
        private readonly IRepository<StockUnit> _repository;
        private readonly IMapper _mapper;
        public GetAllStockUnitsQueryHandler(IRepository<StockUnit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<StockUnitDto>> Handle(GetAllStockUnitsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<StockUnit>, List<StockUnitDto>>(data);
        }
    }
}
