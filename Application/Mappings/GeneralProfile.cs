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
        }
    }
}
