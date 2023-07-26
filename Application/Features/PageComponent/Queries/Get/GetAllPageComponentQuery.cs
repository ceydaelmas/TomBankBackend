using Application.ApiResponse;
using Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PageComponent.Queries.Get
{
    public class GetAllPageComponentQuery : IRequest<Response<IEnumerable<PageComponentModel>>>
    {
    }
}
