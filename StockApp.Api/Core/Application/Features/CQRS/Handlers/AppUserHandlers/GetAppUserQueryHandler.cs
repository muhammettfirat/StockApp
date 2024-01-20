using AutoMapper;
using MediatR;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQueryRequest, AppUserDto>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public GetAppUserQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }


        public async Task<AppUserDto> Handle(GetAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<AppUser, AppUserDto>(data);
        }
    }
}
