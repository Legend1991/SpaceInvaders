namespace SpaceInvaders.Models.Factories
{
    public enum AlienType
    {
        Faeyan, Gaal, Peleng, Maloq
    }

    public interface AlienFactory
    {
        Alien Make(AlienType type, int x, int y);
    }
}
