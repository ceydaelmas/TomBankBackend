using Application.ApiResponse;
using MediatR;

namespace Application.Features.PageComponent.Commands.Delete
{
    public class DeletePageComponentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
