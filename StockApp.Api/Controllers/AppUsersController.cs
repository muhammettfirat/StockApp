using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Core.Application.Features.CQRS.Command.AppUserRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppRoleRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppUserRequests;

namespace StockApp.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediator.Send(new GetAllAppUsersQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new GetAppUserQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteAppUserCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAppUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAppUserCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpGet]
        [Route("GetRoleNameById/{roleId}")]
        public async Task<string> GetRoleNameById(Guid roleId)
        {
            var result = await _mediator.Send(new GetAppRoleQueryRequest(roleId));

            return result?.Description.ToString();
        }
    }
}
