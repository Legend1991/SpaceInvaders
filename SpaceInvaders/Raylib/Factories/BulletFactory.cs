using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Raylib.Factories
{
    public class BulletFactory(Display display, Physics physics) : Models.Factories.BulletFactory
    {
        public Bullet Make(Direction direction, int x, int y)
        {
            var mask = Textures.Mask(Assets.BulletSprite);
            var collider = new CellularCollider(mask, false);

            collider.X = x - (collider.Width / 2);
            collider.Y = y - (direction == Direction.Up ? 0 : collider.Height);

            var sprite = new Sprite(Assets.BulletSprite, collider);
            var bullet = new Bullet(direction)
            {
                Collider = collider
            };

            display.Add(sprite);
            physics.Add(bullet);

            bullet.Destroyed += () =>
            {
                display.Remove(sprite);
                physics.Remove(bullet);
            };

            return bullet;
        }
    }
}
