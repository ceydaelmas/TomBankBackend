using Application.ApiResponse;
using Application.Model;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Component.Queries.Get
{
    public class GetAllComponentsHandler:IRequestHandler<GetAllComponentsQuery,Response<IEnumerable<ComponentModel>>>
    {
        private readonly IComponentRepository _componentRepository;

        public GetAllComponentsHandler(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public async Task<Response<IEnumerable<ComponentModel>>> Handle(GetAllComponentsQuery request, CancellationToken cancellationToken)
        {
            var components = await _componentRepository.GetAllAsync();
            if(components == null)
            {
                return new Response<IEnumerable<ComponentModel>>(false, message: "Component is not found");
            }
            var response = components.Select(component => new ComponentModel
            {
                _id = component._id,
                name = component.name,
                pageId = component.pageId,
                attributes = component.attributes?.Select(attr => new AttributeModel
                {
                    name = attr.name,
                    valueName = attr.valueName,
                }).ToList() ?? new List<AttributeModel>()
            });

            return new Response<IEnumerable<ComponentModel>>(response, true, "Components fetched successfully");

        }
    }
}
