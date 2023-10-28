using SpaceInvaders.Core;
using SpaceInvaders.Models;

namespace SpaceInvaders.Raylib.Factories
{
    public class ObstacleFactory(Display display, Physics physics) : Models.Factories.ObstacleFactory
    {
        public Obstacle Make(float x, float y)
        {
            var mask = Textures.Mask(Sprites.Obstacle);
            var collider = new CellularCollider(mask, true) {
                X = Convert.ToInt32(display.Width * x),
                Y = Convert.ToInt32(display.Height * y)
            };
            var sprite = new Sprite(Sprites.Obstacle, collider);

            display.Add(sprite);

            var obstacle = new Obstacle()
            {
                Collider = collider
            };

            physics.Add(obstacle);

            return obstacle;
        }
    }
}
