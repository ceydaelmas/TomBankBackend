using Application.ApiResponse;
using Application.Model;
using MediatR;

namespace Application.Features.Component.Queries.Get
{
    public class GetAllComponentsQuery : IRequest<Response<IEnumerable<ComponentModel>>>
    {
    }
}
