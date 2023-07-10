using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ApiResponse;
using Domain.IRepositories;
using MediatR;

namespace Application.Features.Tab.Commands.Delete
{
    public class DeleteTabCommandHandler : IRequestHandler<DeleteTabCommand, Response<string>>
    {
        private readonly ITabRepository _tabRepository;

        public DeleteTabCommandHandler(ITabRepository tabRepository)
        {
            _tabRepository = tabRepository;
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
                await _tabRepository.DeleteAsync(request.Id);
                return new Response<string>(true, message: "Tab bilgisi başarıyla silindi");
            }
            catch
            {
                return new Response<string>(false, message: "Tab silinirken bir hata oluştu");
            }
        }
    }
}
