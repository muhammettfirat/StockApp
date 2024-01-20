using StockApp.Api.Core.Application.Dto;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.AppRoleRequests
{
    public class GetAllAppRolesQueryRequest : IRequest<List<AppRoleDto>>
    {
    }
}
