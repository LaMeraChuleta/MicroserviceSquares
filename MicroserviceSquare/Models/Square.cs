using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Models
{
    public class Square
    {
        public string SquareId { get; set; }        
        public string Name { get; set; }  
        public int DelegationId { get; set; }
        [NotMapped]
        public Delegation Delegation { get; set; }
        //relacion 1 - n key null
        //public  Delegation Delegation { get; set; }                
    }
}
