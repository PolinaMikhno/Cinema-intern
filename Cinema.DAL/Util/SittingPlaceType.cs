namespace Cinema.DAL.Entities
{
    public class SittingPlaceType
    {
        public readonly int Size;
        public readonly bool IsVip;

        public SittingPlaceType()
        {
            Size = 1;
        }

        public SittingPlaceType(int size)
        {
            Size = size;
        }

        public SittingPlaceType(bool isVip)
        {
            IsVip = isVip;
        }

        public SittingPlaceType(int size, bool isVip)
        {
            Size = size;
            IsVip = isVip;
        }
    }
}