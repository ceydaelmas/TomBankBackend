using Application.ApiResponse;
using Application.Attributes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tab.Commands.Update
{

    public class UpdateTabCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string TabName { get; set; }

        public string? ParentName { get; set; }

        [FullPathValidation(ErrorMessage = "Invalid fullPath. Please provide a valid rooted file path.")]
        public string? FullPath { get; set; }

        public string? Path { get; set; }
    }
}
