using Application.ApiResponse;
using Application.Model;
using MediatR;

namespace Application.Features.Tab.Queries
{
    public class GetAllTabsForParentQuery : IRequest<Response<IEnumerable<SelectableTabModel>>>
    {
        public int _id { get; set; }
    }
}