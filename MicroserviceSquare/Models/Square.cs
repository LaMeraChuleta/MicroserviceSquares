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
        public  Delegation Delegation { get; set; }                
    }
}
