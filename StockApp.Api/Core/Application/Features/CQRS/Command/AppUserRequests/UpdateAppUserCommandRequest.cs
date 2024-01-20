using StockApp.Api.Core.Application.Dto;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests
{
    public class UpdateAppUserCommandRequest:IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? AppRoleId { get; set; }

    }
}
