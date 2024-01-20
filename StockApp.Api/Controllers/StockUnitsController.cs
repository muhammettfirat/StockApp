using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockUnitRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockUnitRequests;

namespace StockApp.Api.Controllers
{
    //[Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class StockUnitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockUnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediator.Send(new GetAllStockUnitsQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new GetStockUnitQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteStockUnitCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStockUnitCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateStockUnitCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
