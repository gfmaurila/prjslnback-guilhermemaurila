using AutoMapper;
using Prjslnback.Domain.Entities;
using Prjslnback.Services.DTO;
using Prjslnback.Services.DTO.PrjslnbackAPI.ViewModels;

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
