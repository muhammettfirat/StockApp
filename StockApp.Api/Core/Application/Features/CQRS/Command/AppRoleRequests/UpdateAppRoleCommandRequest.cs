using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Helper;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests
{
    public class UpdateAppRoleCommandRequest: IRequest
    {
        public Guid Id { get; set; }
        public RoleTypeEnum? Description { get; set; }

    }
}
