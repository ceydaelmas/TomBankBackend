using Application.Features.Component.Commands.Create;
using Application.Features.Component.Queries.Get;
using Application.Features.PageComponent.Commands.Delete;
using Application.Features.PageComponent.Commands.Update;
using Application.Features.Property.Commands.Create;
using Application.Features.Tab.Commands.Create;
using Application.Features.Tab.Commands.Delete;
using Application.Features.Tab.Commands.Update;
using Application.Features.Tab.Queries;
using Application.Model;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    //Bu sınıf, AutoMapper kütüphanesini kullanarak nesneler arasında dönüşüm (mapping) tanımlar.
    //AutoMapper, bir nesnenin özelliklerini başka bir nesnenin özelliklerine otomatik olarak eşleyen bir .NET kütüphanesidir.
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Tab, TabModel>().ReverseMap();
            CreateMap<Tab, GetAllTabsQuery>().ReverseMap();
            CreateMap<Tab, GetAllTabsForParentQuery>().ReverseMap();
            CreateMap<Tab, CreateTabCommand>().ReverseMap();
            CreateMap<Tab, UpdateTabCommand>().ReverseMap();
            CreateMap<Tab, DeleteTabCommand>().ReverseMap();

            CreateMap<Component, CreateComponentCommand>().ReverseMap();
            CreateMap<Component, GetAllComponentsQuery>().ReverseMap();

            CreateMap<Property, CreatePropertyCommand>().ReverseMap();

            CreateMap<PageComponent, CreateComponentCommand>().ReverseMap();
            CreateMap<PageComponent, UpdatePageComponentCommand>().ReverseMap();
            CreateMap<PageComponent, DeletePageComponentCommand>().ReverseMap();
        }
    }
}
