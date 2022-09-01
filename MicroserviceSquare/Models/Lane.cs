namespace MicroserviceSquare.Models
{
    public class Lane
    {
        public int LaneId { get; set; }
        public int NumberProvider { get; set; }
        public string NumberGea { get; set; }                
        public int TypeLaneId { get; set; }
        public string SquareId { get; set; }
        public int SectionId { get; set; }        
        public  Section Section { get; set; }
        public  Square Square { get; set; }
        public  TypeLane TypeLane { get; set; }        
    }
}
