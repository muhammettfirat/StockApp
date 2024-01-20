using AutoMapper;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppRoleRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppRoleHandlers
{
    public class GetAllAppRolesQueryHandler : IRequestHandler<GetAllAppRolesQueryRequest, List<AppRoleDto>>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;
        public GetAllAppRolesQueryHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AppRoleDto>> Handle(GetAllAppRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<AppRole>, List<AppRoleDto>>(data);
        }
    }
}
