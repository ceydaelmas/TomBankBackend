using Application.ApiResponse;
using Domain.IRepositories;
using MediatR;

namespace Application.Features.Property.Commands.Create
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Response<string>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ICounterRepository _counterRepository;

        public CreatePropertyCommandHandler(IPropertyRepository propertyRepository, ICounterRepository counterRepository)
        {
            _propertyRepository = propertyRepository;
            _counterRepository = counterRepository;
       
        }

        public async Task<Response<string>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetByNameAsync(request.PropertyName);

            if (property == null)
            {
                var nextId = await _counterRepository.GetNextIdAsync("propertyId");

                property = new Domain.Entities.Property
                {
                    _id = nextId,
                    name = request.PropertyName,
                };

                await _propertyRepository.CreateAsync(property);
           
                return new Response<string>(true, message: "Property eklendi");
            }
            else
            {
                return new Response<string>(false, message: "Property zaten ekli");
            }
        }
    }
}