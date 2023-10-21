using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public class Alien(CellCollider collider, Blaster blaster) : IRigidbody
    {
        private readonly int speed = 1;
        private readonly double stepsLimit = 100;
        private readonly Random random = new();

        private int stepsCount = 50;
        private bool moveRight = true;

        public void Update()
        {
            if (stepsCount >= stepsLimit)
            {
                moveRight = !moveRight;
                collider.Y += 10;
                stepsCount = 0;
            }

            if (random.NextDouble() <= 0.0005)
            {
                blaster.Trigger();
            }

            collider.X += moveRight ? speed : -speed;
            stepsCount++;
        }
    }
}
