namespace MicroserviceSquare.Models
{
    public class TypeLane
    {
        public int TypeLaneId { get; set; }        
        public string Name { get; set; }
        public Lane Lane { get; set; }
    }
}
