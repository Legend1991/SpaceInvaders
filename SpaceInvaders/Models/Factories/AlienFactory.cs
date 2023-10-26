namespace SpaceInvaders.Models.Factories
{
    public enum AlienType
    {
        Faeyan, Gaal, Peleng, Maloq
    }

    public interface AlienFactory
    {
        Alien Make(AlienType type, float x, float y);
    }
}
