namespace RoboWars.Game.Actors
{
    public class Arena : IArena
    {
        public uint Latitude { get; private set; }
        public uint Longitude { get; private set; }

        public void SetSize(uint x, uint y)
        {
            Latitude = x;
            Longitude = y;
        }

    }
}