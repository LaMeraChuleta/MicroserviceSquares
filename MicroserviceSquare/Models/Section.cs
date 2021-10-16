using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Models
{
    public class Section
    {
        public int SectionId { get; set; }        
        public string Name { get; set; }
        public string SquareId { get; set; }
        public IEnumerable<Lane> Lanes { get; set; }
        //public  Square Square { get; set; }        
    }
}
