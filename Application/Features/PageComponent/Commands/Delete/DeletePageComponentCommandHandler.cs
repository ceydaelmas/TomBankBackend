using Application.ApiResponse;
using Domain.IRepositories;
using MediatR;


namespace Application.Features.PageComponent.Commands.Delete
{
    public class DeletePageComponentCommandHandler : IRequestHandler<DeletePageComponentCommand, Response<string>>
    {
        private readonly IPageComponentRepository _pageComponentRepository;

        public DeletePageComponentCommandHandler(IPageComponentRepository pageComponentRepository)
        {
            _pageComponentRepository = pageComponentRepository;
        }

        public async Task<Response<string>> Handle(DeletePageComponentCommand request, CancellationToken cancellationToken)
        {
            var pageComponent = await _pageComponentRepository.GetByIdAsync(request.Id);

            if (pageComponent == null)
            {
                return new Response<string>(false, message: "Page-Component bulunamadı");
            }
            try
            {
                await _pageComponentRepository.DeleteAsync(request.Id);
               
                return new Response<string>(true, message: "Page-Component bilgisi başarıyla silindi");
            }
            catch
            {
                return new Response<string>(false, message: "Page-Component silinirken bir hata oluştu");
            }
        }
    }
}
