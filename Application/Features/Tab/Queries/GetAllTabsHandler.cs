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
    //GetAllTabsHandler sınıfının, GetAllTabsQuery türünde bir isteği işleyeceğini ve bu işlem sonucunda IEnumerable<TabModel> türünde bir yanıt döndüreceğini belirtir. Handle bunu bir fonskiyonu.

    public class GetAllTabsHandler : IRequestHandler<GetAllTabsQuery, Response<IEnumerable<TabModel>>>
    {
        //Sınıfın amacı, bir tab deposundan (repository'den) tüm tableri almak ve onları bir model nesnesine dönüştürmektir.
        private readonly ITabRepository _tabRepository;
        //IMapper, veritabanındaki tableri model nesnelerine dönüştürmek için kullanılır.
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllTabsHandler(ITabRepository tabRepository, IMapper mapper, IMemoryCache cache)
        {
            _tabRepository = tabRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Response<IEnumerable<TabModel>>> Handle(GetAllTabsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = "AllTabs";
            // Önbellekte verileri kontrol eder
            if (_cache.TryGetValue(cacheKey, out IEnumerable<TabModel> cachedTabs))
            {
                return new Response<IEnumerable<TabModel>>(cachedTabs, true, "Tabs fetched from cache");
            }

            // Veriler önbellekte bulunamadıysa, veritabanından alır
            // bu GetAllTabsQuery talebini işler. Bu fonksiyon, ITabRepository'den GetAllAsync metodunu çağırarak tüm tableri asenkron bir şekilde alır.
            var tabs = await _tabRepository.GetAllAsync();
            if (tabs == null)
            {
                return new Response<IEnumerable<TabModel>>(false, message: "Tab is not found");
            }

            var response = tabs.Select(tab => new TabModel
            {
                _id = tab._id,
                parentId = tab.parentId,
                path = tab.path,
                name = tab.name,
                fullPath = tab.fullPath,
            }).ToList();

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Önbellek süresi
            };
            _cache.Set(cacheKey, response, cacheOptions);

            return new Response<IEnumerable<TabModel>>(response, true, "Tabs fetched successfully");
        
        }
    }
}
