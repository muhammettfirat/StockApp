using AutoMapper;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockTypeHandlers
{
    public class GetStockTypeQueryHandler : IRequestHandler<GetStockTypeQueryRequest, StockTypeDto>
    {
        private readonly IRepository<StockType> _repository;
        private readonly IMapper _mapper;
        public GetStockTypeQueryHandler(IRepository<StockType> repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

       
        public async Task<StockTypeDto> Handle(GetStockTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<StockType,StockTypeDto>(data);
        }
    }
}
