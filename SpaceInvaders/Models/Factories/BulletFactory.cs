namespace SpaceInvaders.Models.Factories
{
    public enum Direction
    {
        Up, Down
    }

    public interface BulletFactory
    {
        Bullet Make(Direction direction, int x, int y);
    }
}
