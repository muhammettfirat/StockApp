using AutoMapper;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppRoleRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppUserRequests;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Handlers.AppRoleHandlers
{
    public class GetAppRoleQueryHandler : IRequestHandler<GetAppRoleQueryRequest, AppRoleDto>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;
        public GetAppRoleQueryHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }


        public async Task<AppRoleDto> Handle(GetAppRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<AppRole, AppRoleDto>(data);
        }
    }
}
