using StockApp.Api.Core.Application.Dto;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.AppRoleRequests
{
    public class GetAppRoleQueryRequest : IRequest<AppRoleDto>
    {
        public Guid Id { get; set; }
        public GetAppRoleQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
