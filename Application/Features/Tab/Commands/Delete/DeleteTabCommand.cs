using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ApiResponse;
using MediatR;

namespace Application.Features.Tab.Commands.Delete
{
    public class DeleteTabCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
