using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Plane
    {


        public int PlaneId { get; set; }

        [Range(0,int.MaxValue,ErrorMessage = "Only positive number allowed")]
        public int Capacity { get; set; }
        public DateTime ManufactoreDate { get; set; }
        public PlaneType planeType { get; set; }

        public virtual IList<Flight> flights { get; set; }

        public override string ToString() => $"{Capacity} {ManufactoreDate} {planeType} {PlaneId} {flights}";


    }
}
