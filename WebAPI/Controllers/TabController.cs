﻿using Application.Features.Tab.Commands.Create;
using Application.Features.Tab.Commands.Delete;
using Application.Features.Tab.Commands.Update;
using Application.Features.Tab.Queries;
using Application.Model;
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
        [HttpGet("GetAllTabs")]
        [ProducesResponseType(typeof(IEnumerable<TabModel>), 200)]
        public async Task<IActionResult> GetAllTabs()
        {
            //var result= await _tabRepository.GetAllAsync();
            //return Ok(result);
            return Ok(await Mediator.Send(new GetAllTabsQuery()));

        }
        [HttpGet("GetSelectableParentTabs")]
        [ProducesResponseType(typeof(IEnumerable<SelectableTabModel>), 200)]
        public async Task<IActionResult> GetSelectableParentTabs(int id)
        {
            //var result= await _tabRepository.GetAllAsync();
            //return Ok(result);
            return Ok(await Mediator.Send(new GetAllTabsForParentQuery{ _id=id }));

        }

        [HttpPost("AddTab")]
        public async Task<IActionResult> AddCategory(CreateTabCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("UpdateTab")]
        public async Task<IActionResult> UpdateTab(UpdateTabCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("DeleteTab")]
        public async Task<IActionResult> DeleteTab(DeleteTabCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
