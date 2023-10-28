using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Raylib.Factories
{
    public class AlienFactory(Display display, Physics physics) : Models.Factories.AlienFactory
    {
        private readonly BulletFactory bulletFactory = new(display, physics);
        private readonly Dictionary<AlienType, string> sprites = new()
        {
            { AlienType.Faeyan, Sprites.Faeyan },
            { AlienType.Gaal,   Sprites.Gaal },
            { AlienType.Peleng, Sprites.Peleng }
        };

        public Alien Make(AlienType type, float x, float y)
        {
            var mask = Textures.Mask(sprites[type]);
            var collider = new CellularCollider(mask, false)
            {
                X = Convert.ToInt32(display.Width * x),
                Y = Convert.ToInt32(display.Height * y)
            };
            var sprite = new Sprite(sprites[type], collider);
            var alien = new Alien()
            {
                Blaster = new Blaster(bulletFactory, collider, GunSlot.BottomCenter),
                Collider = collider,
            };

            display.Add(sprite);
            physics.Add(alien);
            physics.Add(alien.Blaster);

            alien.Destroyed += () =>
            {
                display.Remove(sprite);
                physics.Remove(alien);
                physics.Remove(alien.Blaster);
            };

            return alien;
        }
    }
}
