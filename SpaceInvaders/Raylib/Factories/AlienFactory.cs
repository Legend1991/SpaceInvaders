using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Raylib.Factories
{
    public class AlienFactory(Display display) : Models.Factories.AlienFactory
    {
        private readonly BulletFactory bulletFactory = new(display);
        private readonly Dictionary<AlienType, string> sprites = new()
        {
            { AlienType.Faeyan, Sprites.Faeyan },
            { AlienType.Gaal,   Sprites.Gaal },
            { AlienType.Peleng, Sprites.Peleng }
        };

        public Alien Make(AlienType type, float x, float y)
        {
            var mask = Textures.Mask(sprites[type]);
            var collider = new CellCollider(mask)
            {
                X = Convert.ToInt32(display.Width * x),
                Y = Convert.ToInt32(display.Height * y)
            };
            var sprite = new Sprite(sprites[type], collider);

            display.Add(sprite);

            var alien = new Alien(collider)
            {
                Blaster = new Blaster(bulletFactory, collider, GunSlot.BottomCenter)
            };
            return alien;
        }
    }
}
