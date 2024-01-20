using StockApp.Api.Core.Application.Dto;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest:IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; }
        public string? Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
