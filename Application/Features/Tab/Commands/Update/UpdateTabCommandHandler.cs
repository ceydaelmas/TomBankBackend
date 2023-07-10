using Amazon.Runtime.Internal;
using Application.ApiResponse;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tab.Commands.Update
{
    public class UpdateTabCommandHandler : IRequestHandler<UpdateTabCommand, Response<string>>
    {
        private readonly ITabRepository _tabRepository;

        public UpdateTabCommandHandler(ITabRepository tabRepository)
        {
            _tabRepository = tabRepository;
        }
        public async Task<Response<string>> Handle(UpdateTabCommand request, CancellationToken cancellationToken)
        {
            var tab = await _tabRepository.GetByIdAsync(request.Id);
            var tabWithName = await _tabRepository.GetByNameAsync(request.TabName);
            if (tabWithName != null && tabWithName._id != request.Id)
            {
                return new Response<string>(false, message: "Tab ismi zaten kullanılıyor");
            }

            int? parentId = null;
            if (!string.IsNullOrEmpty(request.ParentName))
            {
                parentId = await _tabRepository.GetIdByNameAsync(request.ParentName);

                // Check if there is no Tab with the parent name
                if (parentId == null)
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
                return new Response<string>(true, message: "Tab bilgileri düzenlendi");
            }
        }
    }
}
