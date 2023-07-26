﻿using Application.ApiResponse;
using Application.Model;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PageComponent.Commands.Create
{
    public class CreateComponentForPageCommand : IRequest<Response<string>>
    {
        public string ComponentName { get; set; }

        public string Name { get; set; }

        public string PageName { get; set; }

        public List<Value> Values { get; set; }
    }
}
