using Application.Features.Tab.Queries;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabController : BaseController
    {
        //private readonly ITabRepository _tabRepository;
        //public TabController(ITabRepository tabRepository)
           
        //{
        //    _tabRepository = tabRepository;
            
        //}
        [HttpGet("get-all-tabs")]
        public async Task<IActionResult> GetAllTabs()
        {
            //var result= await _tabRepository.GetAllAsync();
            //return Ok(result);
            return Ok(await Mediator.Send(new GetAllTabsQuery()));

        }

    }
}
