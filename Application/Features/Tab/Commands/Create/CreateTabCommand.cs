using Application.ApiResponse;
using Application.Attributes;
using MediatR;

namespace Application.Features.Tab.Commands.Create
{
    public class CreateTabCommand : IRequest<Response<string>>
    {

        public string TabName { get; set; }

        public string? ParentName { get; set; }

        [FullPathValidation(ErrorMessage = "Invalid fullPath. Please provide a valid rooted file path.")]
        public string? FullPath { get; set; }

        public string? Path { get; set; }

    }
}
