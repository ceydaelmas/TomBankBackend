using Application.ApiResponse;
using Application.Features.Component.Queries.Get;
using Application.Model;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PageComponent.Queries.Get
{
    public class GetAllPageComponentHandler : IRequestHandler<GetAllPageComponentQuery, Response<IEnumerable<PageComponentModel>>>
    {
        private readonly IPageComponentRepository _pageComponentRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly ITabRepository _tabRepository;

        public GetAllPageComponentHandler(IPageComponentRepository pageComponentRepository, IPropertyRepository propertyRepository, IComponentRepository componentRepository, ITabRepository tabRepository) 
        {
            _pageComponentRepository = pageComponentRepository;
            _propertyRepository = propertyRepository;
            _componentRepository = componentRepository;
            _tabRepository = tabRepository;
        }

        public async Task<Response<IEnumerable<PageComponentModel>>> Handle(GetAllPageComponentQuery request, CancellationToken cancellationToken)
        {
            var componentsPage = await _pageComponentRepository.GetAllAsync();
            if (componentsPage == null)
            {
                return new Response<IEnumerable<PageComponentModel>>(false, message: "Components are not found");
            }

            var response = new List<PageComponentModel>();

            foreach (var cp in componentsPage)
            {
                var values = new List<Value>();
                foreach (var value in cp.values)
                {
                    var property = await _propertyRepository.GetByNameAsync(value.PropertyName);
                    if (property != null)
                    {
                        values.Add(new Value
                        {
                            PropertyName = property.name,
                            ValueName = value.ValueName
                        });
                    }
                }
                var component = await _componentRepository.GetByIdAsync(cp.componentId);
                var page = await _tabRepository.GetByIdAsync(cp.pageId);
                response.Add(new PageComponentModel
                {
                    _id = cp._id,
                    componentName  = component.name,
                    name = cp.name,
                    pageName =page.name,
                    values = values
                });
            }

            return new Response<IEnumerable<PageComponentModel>>(response, true, "Components fetched successfully");
        }

    }
}
