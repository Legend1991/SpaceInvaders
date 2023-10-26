using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Raylib.Factories
{
    public class BulletFactory(IDisplay display) : Models.Factories.BulletFactory
    {
        public Bullet Make(Direction direction, int x, int y)
        {
            var mask = Textures.Mask(Sprites.Bullet);
            var collider = new CellCollider(mask);

            collider.X = x - (collider.Width / 2);
            collider.Y = y - (direction == Direction.Up ? 0 : collider.Height);

            var entity = new Entity(Sprites.Bullet, collider);
            display.AddEntity(entity);

            return new Bullet(collider, direction);
        }
    }
}
