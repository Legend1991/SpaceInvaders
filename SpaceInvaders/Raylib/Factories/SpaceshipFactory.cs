using SpaceInvaders.Core;
using SpaceInvaders.Models;

namespace SpaceInvaders.Raylib.Factories
{
    public class SpaceshipFactory(Display display, Physics physics) : Models.Factories.SpaceshipFactory
    {
        private readonly BulletFactory bulletFactory = new(display, physics);

        public Spaceship Make(float x, float y)
        {
            var mask = Textures.Mask(Sprites.Spaceship);
            var collider = new CellularCollider(mask, false) {
                X = Convert.ToInt32(display.Width * x),
                Y = Convert.ToInt32(display.Height * y)
            };
            var sprite = new Sprite(Sprites.Spaceship, collider);

            display.Add(sprite);

            var spaceship = new Spaceship(0, display.Width)
            {
                Blaster = new Blaster(bulletFactory, collider, GunSlot.TopCenter),
                Collider = collider,
            };

            physics.Add(spaceship);
            physics.Add(spaceship.Blaster);

            return spaceship;
        }
    }
}
