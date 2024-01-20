using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests
{
    public class DeleteAppUserCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteAppUserCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
