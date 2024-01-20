using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Command
{
    public class RegisterUserCommandRequest : IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Guid? RoleId { get; set; }
        public bool? RememberMe { get; set; }
    }
}
