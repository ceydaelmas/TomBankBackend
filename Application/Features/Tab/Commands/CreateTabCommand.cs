using Application.ApiResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Tab.Commands
{
    public class CreateTabCommand : IRequest<Response<string>>
    {

        public string TabName { get; set; }

        public string? ParentName { get; set; }

    }
}
