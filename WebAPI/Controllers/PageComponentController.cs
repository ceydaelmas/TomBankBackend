using Application.Features.PageComponent.Commands.Create;
using Application.Features.PageComponent.Commands.Delete;
using Application.Features.PageComponent.Commands.Update;
using Application.Features.PageComponent.Queries.Get;
using Application.Features.Property.Commands.Create;
using Application.Features.Tab.Commands.Delete;
using Application.Features.Tab.Commands.Update;
using Application.Features.Tab.Queries;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PageComponentController : BaseController
    {
        [HttpPost("AddComponentToPage")]
        public async Task<IActionResult> AddComponent(CreateComponentForPageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetAllComponentToPage")]
        [ProducesResponseType(typeof(IEnumerable<PageComponentModel>), 200)]
        public async Task<IActionResult> GetAllTabs()
        {
            return Ok(await Mediator.Send(new GetAllPageComponentQuery()));

        }

        [HttpPut("UpdatePageComponent")]
        public async Task<IActionResult> UpdatePageComponent(UpdatePageComponentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("DeletePageComponent")]
        public async Task<IActionResult> DeletePageComponent(DeletePageComponentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
