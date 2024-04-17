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
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(t => new
            {
                t.FlightId,
                t.ReservationId
            });
            builder.HasOne(t => t.Passenger).WithMany(p => p.Reservations).HasForeignKey(t => t.PassengerId);
            builder.HasOne(t => t.Flight).WithMany(f => f.Reservations).HasForeignKey(t => t.FlightId);
        }
    }
}
