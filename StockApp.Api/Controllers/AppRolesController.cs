using StockApp.Api.Core.Application.Features.CQRS.Command.AppRoleRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.AppRoleRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockApp.Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediator.Send(new GetAllAppRolesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new GetAppRoleQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteAppRoleCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAppRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAppRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
