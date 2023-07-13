using Application.ApiResponse;
using Application.Model;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tab.Queries
{
    public class GetAllTabsForParentHandler : IRequestHandler<GetAllTabsForParentQuery, Response<IEnumerable<SelectableTabModel>>>
    {
        //Sınıfın amacı, bir tab deposundan (repository'den) tüm tableri almak ve onları bir model nesnesine dönüştürmektir.
        private readonly ITabRepository _tabRepository;
        //IMapper, veritabanındaki tableri model nesnelerine dönüştürmek için kullanılır.

        public GetAllTabsForParentHandler(ITabRepository tabRepository)
        {
            _tabRepository = tabRepository;

        }

        public async Task<Response<IEnumerable<SelectableTabModel>>> Handle(GetAllTabsForParentQuery request, CancellationToken cancellationToken)
        {


            // Veriler önbellekte bulunamadıysa, veritabanından alır
            // bu GetAllTabsQuery talebini işler. Bu fonksiyon, ITabRepository'den GetAllAsync metodunu çağırarak tüm tableri asenkron bir şekilde alır.
            var tabs = await _tabRepository.GetSelectableParentTabs(request._id);
            if (tabs == null)
            {
                return new Response<IEnumerable<SelectableTabModel>>(false, message: "Tab is not found");
            }

            var response = tabs.Select(tab => new SelectableTabModel
            {
                _id = tab._id,
                name = tab.name,
            });

            return new Response<IEnumerable<SelectableTabModel>>(response, true, "Tabs fetched successfully");

        }
    }
}
