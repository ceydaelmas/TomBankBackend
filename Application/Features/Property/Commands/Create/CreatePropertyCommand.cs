using Application.ApiResponse;
using MediatR;


namespace Application.Features.Property.Commands.Create
{
    public class CreatePropertyCommand : IRequest<Response<string>>
    {
        public string PropertyName { get; set; }
    }
}
