using Application.ApiResponse;
using Application.Model;
using MediatR;

namespace Application.Features.Tab.Queries
{
    public class GetAllTabsQuery : IRequest<Response<IEnumerable<TabModel>>>
    {
    }
}
