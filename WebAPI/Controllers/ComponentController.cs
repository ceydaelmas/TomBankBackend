using Application.Features.Component.Commands.Create;
using Application.Features.Component.Queries.Get;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : BaseController
    {
        [HttpPost("AddComponent")]
        public async Task<IActionResult> AddComponent(CreateComponentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetAllComponents")]
        [ProducesResponseType(typeof(IEnumerable<ComponentModel>), 200)]
        public async Task<IActionResult> GetAllComponents()
        {
            return Ok(await Mediator.Send(new GetAllComponentsQuery()));

        }
    }
}
