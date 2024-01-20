using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Helper;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests
{
    public class CreateAppRoleCommandRequest : IRequest
    {

        public RoleTypeEnum? Description { get; set; }
       
    }
}
