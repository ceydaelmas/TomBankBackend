using Application.ApiResponse;
using Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Component.Commands.Create
{
    public class CreateComponentCommand : IRequest<Response<string>>
    {
        public string ComponentName { get; set; }

        public List<PropertyModel> Properties { get; set; }

    }
}
