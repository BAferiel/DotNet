using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Staff:Passenger
    {
/*        public Staff(string EmailAddress) : this(EmailAddress) { }
 *        
 *        
*/              
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency, ErrorMessage ="Please entter a valid salary ")]
        public float Salary { get; set; }

        public override string ToString() => base.ToString() + $"{EmployementDate} {Function} {Salary}";


        public override string GetPassengerType()
        {
            
            return "Im a staff";
        }

    }


}
