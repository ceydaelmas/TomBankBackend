using Application.ApiResponse;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;


namespace Application.Features.Tab.Commands.Update
{
    public class UpdateTabCommandHandler : IRequestHandler<UpdateTabCommand, Response<string>>
    {
        private readonly ITabRepository _tabRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public UpdateTabCommandHandler(ITabRepository tabRepository, IMapper mapper, IMemoryCache cache)
        {
            _tabRepository = tabRepository;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Response<string>> Handle(UpdateTabCommand request, CancellationToken cancellationToken)
        {
            var tab = await _tabRepository.GetByIdAsync(request.Id);
            var tabWithName = await _tabRepository.GetByNameAsync(request.TabName);
            if (tabWithName != null && tabWithName._id != request.Id)
            {
                return new Response<string>(false, message: "Tab ismi zaten kullanılıyor");
            }

            int parentId =0;
            if (!string.IsNullOrEmpty(request.ParentName))
            {
                parentId = (int)await _tabRepository.GetIdByNameAsync(request.ParentName);

                // Check if there is no Tab with the parent name
                if (parentId == -1)
                {
                    return new Response<string>(false, message: "Parent tab ismi bulunamadı");
                }
            }
            if (tab == null)
            {
                return new Response<string>(false, message: "Tab bilgileri düzenlenirken bir hata oluştu");
            }
            else
            {
                tab.name = request.TabName;
                tab.parentId = parentId;
                tab.path = request.Path;
                tab.fullPath = request.FullPath;

                await _tabRepository.UpdateAsync(tab._id,tab);
                _cache.Remove("AllTabs");
                return new Response<string>(true, message: "Tab bilgileri düzenlendi");
            }
        }
    }
}
