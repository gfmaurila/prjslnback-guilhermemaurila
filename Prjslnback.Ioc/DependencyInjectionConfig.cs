using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prjslnback.Domain.Entities;
using Prjslnback.Infra.Interfaces;
using Prjslnback.Infra.Repositories;
using Prjslnback.Services.DTO;
using Prjslnback.Services.DTO.PrjslnbackAPI.ViewModels;
using Prjslnback.Services.Interfaces;
using Prjslnback.Services.Services;

namespace Prjslnback.Ioc
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjectionConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IEPasswordService, EPasswordService>();
            services.AddTransient<IEPasswordRepository, EPasswordRepository>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();


            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EPassword, EPasswordDTO>().ReverseMap();
                cfg.CreateMap<CreatePasswordViewModel, EPasswordDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            return services;
        }
    }
}
