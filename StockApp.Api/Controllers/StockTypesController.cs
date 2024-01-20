using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Core.Application.Features.CQRS.Command.StockTypeRequests;
using StockApp.Api.Core.Application.Features.CQRS.Queries.StockTypeRequests;

namespace StockApp.Api.Controllers
{
    //[Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class StockTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
           var result= await  _mediator.Send(new GetAllStockTypesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new GetStockTypeQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteStockTypeCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStockTypeCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("",request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateStockTypeCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
