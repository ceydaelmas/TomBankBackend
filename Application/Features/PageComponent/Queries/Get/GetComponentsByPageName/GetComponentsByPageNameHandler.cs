using Application.ApiResponse;
using Application.Model;
using Domain.IRepositories;
using MediatR;

namespace Application.Features.PageComponent.Queries.Get.GetComponentsByPageName
{
    public class GetComponentsByPageNameHandler : IRequestHandler<GetComponentsByPageNameQuery, Response<IEnumerable<ComponentsOfPageModel>>>
    {
        private readonly IPageComponentRepository _pageComponentRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly ITabRepository _tabRepository;

        public GetComponentsByPageNameHandler(IPageComponentRepository pageComponentRepository, IComponentRepository componentRepository, ITabRepository tabRepository)
        {
            _pageComponentRepository = pageComponentRepository;
            _componentRepository = componentRepository;
            _tabRepository = tabRepository;
        }

        public async Task<Response<IEnumerable<ComponentsOfPageModel>>> Handle(GetComponentsByPageNameQuery request, CancellationToken cancellationToken)
        {
            var pageId = await _tabRepository.GetIdByNameAsync(request.PageName);
            if (pageId == -1)
            {
                return new Response<IEnumerable<ComponentsOfPageModel>>(false, message: "Page not found.");
            }
            var pageComponents = await _pageComponentRepository.GetComponentsByPageNameAsync(pageId);

            if (pageComponents == null)
            {
                return new Response<IEnumerable<ComponentsOfPageModel>>(false, message: "No components found for the page.");
            }

            var componentsOfPage = new List<ComponentsOfPageModel>();

            foreach (var cp in pageComponents)
            {
                var component = await _componentRepository.GetByIdAsync(cp.componentId);

                if (component != null)
                {
                    componentsOfPage.Add(new ComponentsOfPageModel
                    {
                        _id = cp._id,
                        componentName = component.name,
                        name = cp.name,
                        values = cp.values
                    });
                }
            }

            return new Response<IEnumerable<ComponentsOfPageModel>>(componentsOfPage, true, "Components of the page fetched successfully.");
        }

    }
}