using Application.ApiResponse;
using MediatR;

namespace Application.Features.Tab.Commands.Delete
{
    public class DeleteTabCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
