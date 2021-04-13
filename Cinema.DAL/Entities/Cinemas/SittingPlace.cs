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
        
        public Vector2 Position;
        public Vector2 Size;
        
        public SittingPlaceType PlaceType;
        
    }
}