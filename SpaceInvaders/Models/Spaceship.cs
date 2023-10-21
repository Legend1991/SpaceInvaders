using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public class Spaceship(CellCollider collider, int minX, int maxX)
    {
        private readonly int speed = 10;

        public void Left()
        {
            var nextX = collider.X - speed;
            collider.X = Math.Clamp(nextX, minX, collider.X);
        }

        public void Right()
        {
            var nextX = collider.X + speed;
            collider.X = Math.Clamp(nextX, collider.X, maxX - collider.Width);
        }
    }
}
