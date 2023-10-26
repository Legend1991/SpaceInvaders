namespace SpaceInvaders.Models.Factories
{
    public interface SpaceshipFactory
    {
        Spaceship Make(int x, int y, int maxY);
    }
}
