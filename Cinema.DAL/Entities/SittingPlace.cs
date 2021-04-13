using Cinema.DAL.Util;

namespace Cinema.DAL.Entities
{
    public class SittingPlace
    {
        /*
         * Position -------------------- X+
         * |                             |
         * |                             |
         * |                             |
         * |                             |
         * |                             |
         * |                             |
         * Y+ ------------ Position + Size
         */ 
        
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        
        public SittingPlaceType PlaceType { get; set; }
        
    }
}