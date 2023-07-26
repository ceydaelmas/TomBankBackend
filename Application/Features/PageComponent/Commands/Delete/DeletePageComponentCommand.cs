using Application.ApiResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PageComponent.Commands.Delete
{
    public class DeletePageComponentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
