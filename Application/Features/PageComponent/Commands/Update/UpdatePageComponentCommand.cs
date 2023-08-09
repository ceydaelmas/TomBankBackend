using Application.ApiResponse;
using Domain.Entities;
using MediatR;

namespace Application.Features.PageComponent.Commands.Update
{
    public class UpdatePageComponentCommand : IRequest<Response<string>>
    {
        public int _id { get; set; }

        public string ComponentName { get; set; }

        public string Name { get; set; }

        public string PageName { get; set; }

        public List<Value> Values { get; set; }
    }
}
