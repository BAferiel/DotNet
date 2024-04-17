using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {

        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        public DateTime BirdthDate { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }
        [MinLength(3), MaxLength(25, ErrorMessage = "Taille maximal 25")]
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public long Telnumber { get; set; }
        [Key, MaxLength(7, ErrorMessage = "Max length for Passport Number is 7 ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PassportNumber { get; set; }

        public int Age { get; }

        public virtual IList<Flight> flights { get; set; }

        public override string ToString() => $"{EmailAddress} {FullName.FirstName} {FullName.LastName} {Telnumber} {PassportNumber}";

        public virtual IList<Reservation>? Reservations { get; set; }


        public virtual FullName FullName { get; set; }

        public virtual string GetPassengerType()
        {
            return "Im a passenger";
        }



    }
}
