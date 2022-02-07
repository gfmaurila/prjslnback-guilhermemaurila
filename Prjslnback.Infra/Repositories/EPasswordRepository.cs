using Prjslnback.Domain.Entities;
using Prjslnback.Infra.Context;
using Prjslnback.Infra.Interfaces;

namespace Prjslnback.Infra.Repositories
{
    public class EPasswordRepository : BaseRepository<EPassword>, IEPasswordRepository
    {
        private readonly PrjslnbackContext _context;

        public EPasswordRepository(PrjslnbackContext context) : base(context)
        {
            _context = context;
        }
    }
}
