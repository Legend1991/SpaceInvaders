using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Raylib.Factories
{
    public class AlienFactory(IDisplay display) : Models.Factories.AlienFactory
    {
        private readonly BulletFactory bulletFactory = new(display);
        private readonly Dictionary<AlienType, string> sprites = new()
        {
            { AlienType.Faeyan, Sprites.Faeyan },
            { AlienType.Gaal,   Sprites.Gaal },
            { AlienType.Peleng, Sprites.Peleng }
        };

        public Alien Make(AlienType type, int x, int y)
        {
            var mask = Textures.Mask(sprites[type]);
            var collider = new CellCollider(mask) { X = x, Y = y };
            var entity = new Entity(sprites[type], collider);

            display.AddEntity(entity);

            var alien = new Alien(collider)
            {
                Blaster = new Blaster(bulletFactory, collider, GunSlot.BottomCenter)
            };
            return alien;
        }
    }
}
