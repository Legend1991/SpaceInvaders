using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Raylib.Factories
{
    public class BulletFactory(Display display, Physics physics) : Models.Factories.BulletFactory
    {
        public Bullet Make(Direction direction, int x, int y)
        {
            var mask = Textures.Mask(Sprites.Bullet);
            var collider = new CellularCollider(mask);

            collider.X = x - (collider.Width / 2);
            collider.Y = y - (direction == Direction.Up ? 0 : collider.Height);

            var sprite = new Sprite(Sprites.Bullet, collider);
            display.Add(sprite);

            var bullet = new Bullet(direction)
            {
                Collider = collider
            };

            physics.Add(bullet);

            return bullet;
        }
    }
}
