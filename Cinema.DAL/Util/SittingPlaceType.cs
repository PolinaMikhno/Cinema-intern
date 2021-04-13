namespace Cinema.DAL.Util
{
    public class SittingPlaceType
    {
        public readonly int Size;
        public readonly bool IsVip;

        public SittingPlaceType(int size = 1, bool isVip = false)
        {
            Size = size;
            IsVip = isVip;
        }
    }
}