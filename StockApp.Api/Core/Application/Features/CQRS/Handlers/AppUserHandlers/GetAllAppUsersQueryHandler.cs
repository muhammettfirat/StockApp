using AutoMapper;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class GetAllAppUsersQueryHandler : IRequestHandler<GetAllAppUsersQueryRequest, List<AppUserDto>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public GetAllAppUsersQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AppUserDto>> Handle(GetAllAppUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<AppUser>, List<AppUserDto>>(data);
        }
    }
}
