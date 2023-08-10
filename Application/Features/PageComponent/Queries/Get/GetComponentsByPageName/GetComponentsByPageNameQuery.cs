using Application.ApiResponse;
using Application.Model;
using MediatR;

namespace Application.Features.PageComponent.Queries.Get.GetComponentsByPageName
{
    public class GetComponentsByPageNameQuery : IRequest<Response<IEnumerable<ComponentsOfPageModel>>>
    {
        public string PageName { get; set; }

    }
}
