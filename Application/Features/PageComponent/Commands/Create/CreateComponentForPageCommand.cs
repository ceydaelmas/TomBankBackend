using Application.ApiResponse;
using Domain.Entities;
using MediatR;

namespace Application.Features.PageComponent.Commands.Create
{
    public class CreateComponentForPageCommand : IRequest<Response<string>>
    {
        public string ComponentName { get; set; }

        public string Name { get; set; }

        public string PageName { get; set; }

        public List<Value> Values { get; set; }
    }
}
