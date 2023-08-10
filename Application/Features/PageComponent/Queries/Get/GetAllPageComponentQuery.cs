using Application.ApiResponse;
using Application.Model;
using MediatR;

namespace Application.Features.PageComponent.Queries.Get
{
    public class GetAllPageComponentQuery : IRequest<Response<IEnumerable<PageComponentModel>>>
    {
    }
}
