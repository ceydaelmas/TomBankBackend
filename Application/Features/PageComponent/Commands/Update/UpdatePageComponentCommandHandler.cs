using Application.ApiResponse;
using Application.Features.Tab.Commands.Update;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PageComponent.Commands.Update
{
    public class UpdatePageComponentCommandHandler : IRequestHandler<UpdatePageComponentCommand, Response<string>>
    {
        private readonly IPageComponentRepository _pageComponentRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly ITabRepository _tabRepository;

        public UpdatePageComponentCommandHandler(IPageComponentRepository pageComponentRepository, IComponentRepository componentRepository, ITabRepository tabRepository)
        {
            _pageComponentRepository = pageComponentRepository;
            _componentRepository = componentRepository;
            _tabRepository = tabRepository;
        }

        public async Task<Response<string>> Handle(UpdatePageComponentCommand request, CancellationToken cancellationToken)
        {
            var pageComponent = await _pageComponentRepository.GetByIdAsync(request._id);
            var pageComponentWithName = await _pageComponentRepository.GetByNameAsync(request.Name);

            if (pageComponent == null)
            {
                return new Response<string>(false, message: "Böyle bir kayıt yok.");
            }
            if (pageComponentWithName != null && pageComponentWithName._id != request._id)
            {
                return new Response<string>(false, message: "Name zaten başka bir component tarafından kullanılıyor");
            }

            var component = await _componentRepository.GetByNameAsync(request.ComponentName);

            // Check if there is no Tab with the parent name
            if (component == null)
            {
                return new Response<string>(false, message: $"{request.ComponentName} - Component is not found.");
            }

            var tab = await _tabRepository.GetByNameAsync(request.PageName);
            if (tab == null)
            {
                return new Response<string>(false, message: $"{request.PageName} - Page is not found.");

            }
           
            else
            {
                pageComponent.componentId = component._id;
                pageComponent.name = request.Name;
                pageComponent.pageId = tab._id;
                pageComponent.values = request.Values;

                await _pageComponentRepository.UpdateAsync(pageComponent._id, pageComponent);
    
                return new Response<string>(true, message: "Bilgiler düzenlendi");
            }
        }
    }
}
