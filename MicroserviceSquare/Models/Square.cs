using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Models
{
    public class Square
    {
        public string SquareId { get; set; }        
        public string Name { get; set; }
        public string DelegationId { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public IEnumerable<Lane> Lanes { get; set; }
        //public  Delegation Delegation { get; set; }                
    }
}
