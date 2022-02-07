using AutoMapper;
using Prjslnback.API.ViewModels;
using Prjslnback.Domain.Entities;
using Prjslnback.Services.DTO;

namespace Prjslnback.Tests.Configurations.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EPassword, EPasswordDTO>()
                    .ReverseMap();

                cfg.CreateMap<CreatePasswordViewModel, EPasswordDTO>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
