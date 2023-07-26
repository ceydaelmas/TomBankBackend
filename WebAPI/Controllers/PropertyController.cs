using Application.Features.Component.Commands.Create;
using Application.Features.Property.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseController
    {
        [HttpPost("AddProperty")]
        public async Task<IActionResult> AddProperty(CreatePropertyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
