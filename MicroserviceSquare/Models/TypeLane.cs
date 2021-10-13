using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Models
{
    public class TypeLane
    {
        public int TypeLaneId { get; set; }        
        public string Name { get; set; }
        public Lane Lane { get; set; }
    }
}
