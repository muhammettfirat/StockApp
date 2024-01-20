using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Domain;
using MediatR;

namespace StockApp.Api.Core.Application.Features.CQRS.Queries.AppUserRequests
{
    public class GetAllAppUsersQueryRequest : IRequest<List<AppUserDto>>
    {
    }
}
