using Application.ApiResponse;
using Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Component.Queries.Get
{
    public class GetAllComponentsQuery : IRequest<Response<IEnumerable<ComponentModel>>>
    {
    }
}
