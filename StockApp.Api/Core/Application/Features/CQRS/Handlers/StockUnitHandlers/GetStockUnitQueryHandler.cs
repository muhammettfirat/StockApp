using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockUnitRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockUnitHandlers
{
    public class GetStockUnitQueryHandler : IRequestHandler<GetStockUnitQueryRequest, StockUnitDto>
    {
        private readonly IRepository<StockUnit> _repository;
        private readonly IMapper _mapper;
        public GetStockUnitQueryHandler(IRepository<StockUnit> repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }


        public async Task<StockUnitDto> Handle(GetStockUnitQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<StockUnit, StockUnitDto>(data);
        }
    }
}
