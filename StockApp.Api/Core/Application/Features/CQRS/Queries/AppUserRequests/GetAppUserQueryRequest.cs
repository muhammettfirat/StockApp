using StockApp.Api.Core.Application.Dto;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.AppUserRequests
{
    public class GetAppUserQueryRequest : IRequest<AppUserDto>
    {
        public Guid Id { get; set; }
        public GetAppUserQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
