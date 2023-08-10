using Application.ApiResponse;
using Domain.IRepositories;
using MediatR;

namespace Application.Features.Component.Commands.Create
{
    public class CreateComponentCommandHandler : IRequestHandler<CreateComponentCommand, Response<string>>
    {
        private readonly IComponentRepository _componentRepository;
        private readonly ICounterRepository _counterRepository;
        private readonly IPropertyRepository _propertyRepository;


        public CreateComponentCommandHandler(IComponentRepository componentRepository, IPropertyRepository propertyRepository, ICounterRepository counterRepository)
        {
            _componentRepository = componentRepository;
            _counterRepository = counterRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Response<string>> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            var nextComponentId = await _counterRepository.GetNextIdAsync("componentId");
            var component = new Domain.Entities.Component
            {
                _id = nextComponentId,
                name = request.ComponentName,
                properties = new List<Domain.Entities.Property>()
            };
            await _componentRepository.CreateAsync(component);

            var existingProperties = await _propertyRepository.GetAllAsync(); // Mevcut Property'leri çekin

            foreach (var propertyModel in request.Properties)
            {
                var existingProperty = existingProperties.FirstOrDefault(p => p.name == propertyModel.name);

                if (existingProperty != null)
                {
                    component.properties.Add(existingProperty); // Mevcut Property kullanılıyor
                }
                else
                {
                    var nextPropertyId = await _counterRepository.GetNextIdAsync("propertyId");
                    var property = new Domain.Entities.Property
                    {
                        _id = nextPropertyId,
                        name = propertyModel.name,
                    };

                    await _propertyRepository.CreateAsync(property);
                    component.properties.Add(property);
                }
            }

            await _componentRepository.UpdateAsync(component._id, component);

            return new Response<string>(true, message: "Component oluşturuldu.");
        }

    }
}