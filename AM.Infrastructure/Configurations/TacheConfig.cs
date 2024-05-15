using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.Infrastructure.Configurations
{
    public class TacheConfig : IEntityTypeConfiguration<Tache>
    {
        public void Configure(EntityTypeBuilder<Tache> builder)
        {
            builder.HasOne(a => a.Membre).WithMany(c => c.Taches).HasForeignKey(c => c.MembreKey);

            builder.HasOne(f => f.Sprint).WithMany(c => c.Taches).HasForeignKey(c => c.SprintKey);

          

        }
    }
}