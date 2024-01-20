using StockApp.Api.Core.Application.Features.CQRS.Command;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries;
using StockApp.Api.Core.Domain;
using StockApp.Api.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace StockApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await this.mediator.Send(request);
            if ((bool)dto.IsExist)
            {
                return Created("", JwtGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adi veya sifre hatali");
            }
        }
    }
}
