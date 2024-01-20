using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests
{
    public class DeleteAppRoleCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteAppRoleCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
