using Application.ApiResponse;
using Application.Features.Component.Commands.Create;
using Application.Model;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PageComponent.Commands.Create
{
    public class CreateComponentForPageCommandHandler : IRequestHandler<CreateComponentForPageCommand, Response<string>>
    {
        private readonly IPageComponentRepository _pageComponentRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly ICounterRepository _counterRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly ITabRepository _tabRepository;

        public CreateComponentForPageCommandHandler(IPageComponentRepository pageComponentRepository, IComponentRepository componentRepository, ICounterRepository counterRepository, IPropertyRepository propertyRepository, ITabRepository tabRepository)
        {
            _pageComponentRepository = pageComponentRepository;
            _componentRepository = componentRepository;
            _counterRepository = counterRepository;
            _propertyRepository = propertyRepository;
            _tabRepository = tabRepository;
        }

        public async Task<Response<string>> Handle(CreateComponentForPageCommand request, CancellationToken cancellationToken)
        {
            var nextPageComponentId = await _counterRepository.GetNextIdAsync("pageComponentId");
            var component = await _componentRepository.GetByNameAsync(request.ComponentName);
            if (component == null)
            {
                return new Response<string>(false, message: $"{request.ComponentName} - Component is not found.");

            }
            var tab = await _tabRepository.GetByNameAsync(request.PageName);
            if (tab == null)
            {
                return new Response<string>(false, message: $"{request.PageName} - Page is not found.");

            }
            var pageComponent = new Domain.Entities.PageComponent
            {
                _id = nextPageComponentId,
                componentId = component._id,
                name = request.Name,
                pageId = tab._id,
                values = new List<Value>()

            };
            var existingComponent = await _pageComponentRepository.GetByNameAsync(request.Name);
            if (existingComponent != null)
            {
                return new Response<string>(false, message: $"Component with the name '{request.Name}' already exists.");
            }

            var existingProperties = await _propertyRepository.GetAllAsync(); // Mevcut Property'leri çekin

            foreach (var valueModel in request.Values)
            {
                var existingProperty = existingProperties.FirstOrDefault(p => p.name == valueModel.PropertyName);

                if (existingProperty != null)
                {
                    pageComponent.values.Add(new Value
                    { 
                        PropertyName = existingProperty.name,
                        ValueName = valueModel.ValueName,
                    });
                }
                else
                {
                    var nextPropertyId = await _counterRepository.GetNextIdAsync("propertyId");
                    var property = new Domain.Entities.Property
                    {
                        _id = nextPropertyId,
                        name = valueModel.PropertyName,
                    };

                    await _propertyRepository.CreateAsync(property);

                    pageComponent.values.Add(new Value
                    {
                        PropertyName = property.name,
                        ValueName = valueModel.ValueName,
                    });
                }
            }

            await _pageComponentRepository.CreateAsync(pageComponent);

            return new Response<string>(true, message: $"'{request.PageName}' sayfasında '{request.ComponentName}' oluşturuldu.");
        }
    }
}