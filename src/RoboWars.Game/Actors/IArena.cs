namespace RoboWars.Game.Actors
{
    public interface IArena
    {
        uint Latitude { get; }
        uint Longitude { get; }

        void SetSize(uint x, uint y);

    }
}