using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configuration
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.FlighttId);
            builder.HasOne(f=>f.plane).WithMany(p=>p.flights).HasForeignKey(f=>f.PlaneId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
