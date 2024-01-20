using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockCardRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockCardRequests;

namespace StockApp.Api.Controllers
{
    //[Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class StockCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediator.Send(new GetAllStockCardsQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new GetStockCardQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteStockCardCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStockCardCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateStockCardCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
