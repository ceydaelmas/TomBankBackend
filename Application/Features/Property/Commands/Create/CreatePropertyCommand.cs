using Application.ApiResponse;
using Application.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Property.Commands.Create
{
    public class CreatePropertyCommand : IRequest<Response<string>>
    {
        public string PropertyName { get; set; }
    }
}
