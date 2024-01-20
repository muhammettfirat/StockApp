using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.StockTypeHandlers
{
    public class CreateStockTypeCommandHandler : IRequestHandler<CreateStockTypeCommandRequest>
    {
        private readonly IRepository<StockType> _repository;
        private readonly IMapper _mapper;
        public CreateStockTypeCommandHandler(IRepository<StockType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new StockType
            {
               
                Name = request.Name,
                Approval = request.Approval
            });
            return Unit.Value;
        }
    }
}
