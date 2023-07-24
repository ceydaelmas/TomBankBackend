using Application.ApiResponse;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Domain.Entities.Attribute;

namespace Application.Features.Component.Commands.Create
{
    public static class AttributeNames
    {
        public const string Color = "color";
        public const string Placeholder = "placeholder";
        public const string Size = "size";
        // Diğer attribute isimlerini buraya ekleyebilirsiniz
    }

    public class CreateComponentCommandHandler : IRequestHandler<CreateComponentCommand, Response<string>>
    {
        private readonly IComponentRepository _componentRepository;
        private readonly ICounterRepository _counterRepository;
        private readonly IAttributeRepository _attributeRepository;


        public CreateComponentCommandHandler(IComponentRepository componentRepository, IAttributeRepository attributeRepository, ICounterRepository counterRepository)
        {
            _componentRepository = componentRepository;
            _counterRepository = counterRepository;
            _attributeRepository = attributeRepository;
        }

        public async Task<Response<string>> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            var nextComponentId = await _counterRepository.GetNextIdAsync("componentId");
            var component = new Domain.Entities.Component
            {
                _id = nextComponentId,
                name = request.ComponentName,
                pageId = request.PageId,
                attributes = new List<Attribute>()
            };
            await _componentRepository.CreateAsync(component);
            var attributeNames = GetAttributeNamesForComponent(request.ComponentName);

            foreach (var attributeModel in request.Attributes)
            {
                // Sadece tanımlı attribute isimlerine izin verin
                if (!attributeNames.Contains(attributeModel.name))
                {
                    return new Response<string>(false, message: $"Invalid attribute name: {attributeModel.name}");
                }

                // Yeni bir Attribute oluşturun
                var nextAttributeId = await _counterRepository.GetNextIdAsync("attributeId");
                var attribute = new Domain.Entities.Attribute
                {
                    _id = nextAttributeId,
                    name = attributeModel.name,
                    valueName = attributeModel.valueName,
                    componentId = component._id
                };

                // Attribute'ün ID'sini Component'e ekleyin (AttributeModel içindeki _id alanı)
                await _attributeRepository.CreateAsync(attribute);
                component.attributes.Add(attribute);
            }
            await _componentRepository.UpdateAsync(component._id, component);

            return new Response<string>(true, message: "Component oluşturuldu.");
        }

        // Component için sabit attribute isimlerini döndüren bir yardımcı metot
        private List<string> GetAttributeNamesForComponent(string componentName)
        {
            // Örnek olarak, Input componenti için tanımlı attribute isimlerini döndürelim
            if (componentName == "Input")
            {
                return new List<string> { AttributeNames.Color, AttributeNames.Placeholder, AttributeNames.Size };
            }
            if (componentName == "Checbox")
            {
                return new List<string> { AttributeNames.Color, AttributeNames.Placeholder, AttributeNames.Size };
            }

            return new List<string>();
        }
    }
}