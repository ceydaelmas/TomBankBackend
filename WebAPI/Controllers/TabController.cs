﻿using Application.ApiResponse;
using Application.Features.Tab.Commands.Create;
using Application.Features.Tab.Commands.Delete;
using Application.Features.Tab.Commands.Update;
using Application.Features.Tab.Queries;
using Application.Model;
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
            if (!ModelState.IsValid)
            {
                // Model doğrulaması başarısız olursa, hataları işleyin veya uyarı döndürün.
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                var response = new Response<object>(false, "Validation failed")
                {
                    Errors = errors.ToList()
                };
                return BadRequest(response);
            }
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
