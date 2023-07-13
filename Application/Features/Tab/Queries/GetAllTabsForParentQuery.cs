using Application.ApiResponse;
using Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tab.Queries
{
    public class GetAllTabsForParentQuery : IRequest<Response<IEnumerable<SelectableTabModel>>>
    {
        public int _id { get; set; }
    }
}