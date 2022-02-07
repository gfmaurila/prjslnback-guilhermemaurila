using AutoMapper;
using Prjslnback.Domain.Entities;
using Prjslnback.Infra.Interfaces;
using Prjslnback.Services.DTO;
using Prjslnback.Services.Interfaces;
using System.Threading.Tasks;

namespace Prjslnback.Services.Services
{
    public class EPasswordService : IEPasswordService
    {

        private readonly IMapper _mapper;
        private readonly IEPasswordRepository _repository;

        public EPasswordService(
            IMapper mapper,
            IEPasswordRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EPasswordDTO> Create(EPasswordDTO dto)
        {
            var mapper = _mapper.Map<EPassword>(dto);
            mapper.Validate();
            mapper.ChangePassword(mapper.Password);

            var passwordCreated = await _repository.Create(mapper);

            return _mapper.Map<EPasswordDTO>(passwordCreated);
        }

        public bool Validator(EPasswordDTO dto)
        {
            var mapper = _mapper.Map<EPassword>(dto);
            mapper.Validate();
            return mapper.Validate();
        }
    }
}
