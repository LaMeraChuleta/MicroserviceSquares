using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.ModelsHelper.Lane
{
    public class LaneInsert
    {
        public int LaneId { get; set; }
        public int NumberProvider { get; set; }
        public string NumberGea { get; set; }
        public int TypeLaneId { get; set; }
        public string SectionId { get; set; }
        public string SquareId { get; set; }        
    }
}
