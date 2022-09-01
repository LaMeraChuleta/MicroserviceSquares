using System.Collections.Generic;

namespace MicroserviceSquare.Models
{
    public class Delegation
    {
        public string DelegationId { get; set; }
        public string Name { get; set; }        
        public IEnumerable<Square> Squares { get; set; }
    }
}
