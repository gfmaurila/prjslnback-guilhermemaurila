using Prjslnback.Services.DTO;
using System.Threading.Tasks;

namespace Prjslnback.Services.Interfaces
{
    public interface IEPasswordService
    {
        Task<EPasswordDTO> Create(EPasswordDTO dto);
        bool Validator(EPasswordDTO dto);
    }
}
