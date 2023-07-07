using Application.Model;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tab.Queries
{
    //GetAllTabsHandler sınıfının, GetAllTabsQuery türünde bir isteği işleyeceğini ve bu işlem sonucunda IEnumerable<TabModel> türünde bir yanıt döndüreceğini belirtir. Handle bunu bir fonskiyonu.


    public class GetAllTabsHandler : IRequestHandler<GetAllTabsQuery, IEnumerable<TabModel>>
    {
        //Sınıfın amacı, bir tab deposundan (repository'den) tüm tableri almak ve onları bir model nesnesine dönüştürmektir.
        private readonly ITabRepository _tabRepository;
        //IMapper, veritabanındaki tableri model nesnelerine dönüştürmek için kullanılır.
        private readonly IMapper _mapper;

        public GetAllTabsHandler(ITabRepository tabRepository, IMapper mapper)
        {
            _tabRepository = tabRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TabModel>> Handle(GetAllTabsQuery request, CancellationToken cancellationToken)
        {
            // bu GetAllTabsQuery talebini işler. Bu fonksiyon, ITabRepository'den GetAllAsync metodunu çağırarak tüm tableri asenkron bir şekilde alır.
            var tabs = await _tabRepository.GetAllAsync();
            var tabViewModel = _mapper.Map<IEnumerable<TabModel>>(tabs);
            //Aldığı tableri IMapper'ın Map fonksiyonu ile TabModel'lara dönüştürür. 
            return tabViewModel;
        }
    }
}
