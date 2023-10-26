using SpaceInvaders.Core;
using SpaceInvaders.Models;

namespace SpaceInvaders.Raylib.Factories
{
    public class SpaceshipFactory(IDisplay display) : Models.Factories.SpaceshipFactory
    {
        private readonly BulletFactory bulletFactory = new(display);

        public Spaceship Make(int x, int y, int maxY)
        {
            var mask = Textures.Mask(Sprites.Spaceship);
            var collider = new CellCollider(mask) { X = x, Y = y };
            var entity = new Entity(Sprites.Spaceship, collider);

            display.AddEntity(entity);

            var spaceship = new Spaceship(collider, 0, maxY)
            {
                Blaster = new Blaster(bulletFactory, collider, GunSlot.TopCenter)
            };

            return spaceship;
        }
    }
}
