using Application.ApiResponse;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tab.Commands
{
    public class CreateTabCommandHandler : IRequestHandler<CreateTabCommand, Response<string>>
    {
        private readonly ITabRepository _tabRepository;
        private readonly ICounterRepository _counterRepository;

        public CreateTabCommandHandler(ITabRepository categoryRepository, ICounterRepository counterRepository)
        {
            _tabRepository = categoryRepository;
            _counterRepository = counterRepository;

        }

        public async Task<Response<string>> Handle(CreateTabCommand request, CancellationToken cancellationToken)
        {
            var tab = await _tabRepository.GetByNameAsync(request.TabName);

            if (tab == null)
            {
                int? parentId = null;

                if (!string.IsNullOrEmpty(request.ParentName))
                {
                    if (!await _tabRepository.ExistsAsync(request.ParentName))
                    {
                        return new Response<string>(false, message: "Parent tab bulunamadı.");
                    }

                    parentId = await _tabRepository.GetIdByNameAsync(request.ParentName);
                }

                var nextId = await _counterRepository.GetNextIdAsync("tabId");

                tab = new Domain.Entities.Tab
                {
                    _id = nextId,
                    name = request.TabName,
                    parentId = parentId ?? 0
                };

                await _tabRepository.CreateAsync(tab);
                return new Response<string>(true, message: "tab eklendi");
            }
            else
            {
                return new Response<string>(true, message: "tab zaten ekli");
            }
        }
    }
}