using Application.ApiResponse;
using Application.Model;
using MediatR;


namespace Application.Features.Component.Commands.Create
{
    public class CreateComponentCommand : IRequest<Response<string>>
    {
        public string ComponentName { get; set; } = null!;

        public List<PropertyModel> Properties { get; set; } = null!;

    }
}
