using Microsoft.EntityFrameworkCore;
using Prjslnback.Domain.Entities;
using Prjslnback.Infra.Mappings;

namespace Prjslnback.Infra.Context
{
    public class PrjslnbackContext : DbContext
    {
        public PrjslnbackContext()
        { }

        public PrjslnbackContext(DbContextOptions<PrjslnbackContext> options) : base(options)
        { }

        public virtual DbSet<EPassword> EPassword { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EPasswordMap());
        }
    }
}
