using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ApiResponse;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Tab.Commands.Delete
{
    public class DeleteTabCommandHandler : IRequestHandler<DeleteTabCommand, Response<string>>
    {
        private readonly ITabRepository _tabRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public DeleteTabCommandHandler(ITabRepository tabRepository, IMapper mapper, IMemoryCache cache)
        {
            _tabRepository = tabRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Response<string>> Handle(DeleteTabCommand request, CancellationToken cancellationToken)
        {
            var tab = await _tabRepository.GetByIdAsync(request.Id);

            if (tab == null)
            {
                return new Response<string>(false, message: "Tab bulunamadı");
            }
            try
            {
                // Silinmekte olan Tab'ın adını alıyoruz.
                var deletingTabId = tab._id;

                // Tüm Tab'ları alıyoruz.
                var allTabs = await _tabRepository.GetAllAsync();

                // Silinen Tab'ın adıyla eşleşen bir parent adı buluyoruz.
                var matchingTabs = allTabs.Where(t => t.parentId == deletingTabId);

                // Eşleşen her Tab için parentId'ini boşa çıkarıyoruz.
                foreach (var matchingTab in matchingTabs)
                {
                    matchingTab.parentId = 0; // Veya herhangi bir 'boş' değer.
                    await _tabRepository.UpdateAsync(matchingTab._id, matchingTab);
                }

                await _tabRepository.DeleteAsync(request.Id);
                _cache.Remove("AllTabs");
                return new Response<string>(true, message: "Tab bilgisi başarıyla silindi");
            }
            catch
            {
                return new Response<string>(false, message: "Tab silinirken bir hata oluştu");
            }
        }
    }
}
