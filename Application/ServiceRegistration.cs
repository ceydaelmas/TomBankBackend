using Application.Features.Component.Commands.Create;
using Application.Features.Component.Queries.Get;
using Application.Features.PageComponent.Commands.Create;
using Application.Features.PageComponent.Commands.Delete;
using Application.Features.PageComponent.Commands.Update;
using Application.Features.PageComponent.Queries.Get;
using Application.Features.PageComponent.Queries.Get.GetComponentsByPageName;
using Application.Features.Property.Commands.Create;
using Application.Features.Tab.Commands.Create;
using Application.Features.Tab.Commands.Delete;
using Application.Features.Tab.Commands.Update;
using Application.Features.Tab.Queries;
using Application.Mappings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    //IServiceCollection .NET Core'da servislerin kaydedildiği bir containerdır. 
    //IConfiguration ise uygulamanın yapılandırma (configuration) ayarlarına erişim sağlar.
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(GeneralProfile).Assembly);
            //Bu sayede AutoMapper, GeneralProfile sınıfındaki tüm mappingleri tanır.

            services.AddMediatR(typeof(GetAllTabsHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllTabsForParentHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateTabCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateTabCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteTabCommandHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetAllComponentsHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateComponentCommandHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CreatePropertyCommandHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CreateComponentForPageCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllPageComponentHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetComponentsByPageNameHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePageComponentCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeletePageComponentCommandHandler).GetTypeInfo().Assembly);
            // Bu satırda MediatR servisi kaydedilir ve hangi handler'ların kullanılacağı belirtilir. Bu sayede MediatR, GetAllTabsHandler sınıfındaki tüm handler'ları tanır
        }
    }
}
