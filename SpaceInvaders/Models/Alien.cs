using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public class Alien : Rigidbody
    {
        private readonly int speed = 1;
        private readonly double stepsLimit = 100;
        private readonly Random random = new();

        private int stepsCount = 50;
        private bool moveRight = true;

        private double movement = 0;

        public override void FixedUpdate()
        {
            if (stepsCount >= stepsLimit)
            {
                moveRight = !moveRight;
                Collider.Y += 10;
                stepsCount = 0;
            }

            Collider.X += moveRight ? speed : -speed;
            stepsCount++;

            if (random.NextDouble() <= 0.0005)
            {
                Blaster?.Trigger();
            }
        }

        public override void Update(double deltaTime)
        {
            //if (stepsCount >= stepsLimit)
            //{
            //    moveRight = !moveRight;
            //    Collider.Y += 10;
            //    stepsCount = 0;
            //}

            //movement += (speed * (deltaTime / 20.0f));
            //if (movement > 1)
            //{
            //    int shift = (int)movement;
            //    Collider.X += moveRight ? shift : -shift;
            //    movement -= shift;
            //}
            //stepsCount += 1 * (deltaTime / 20.0f);

            //if (random.NextDouble() <= 0.0005)
            //{
            //    Blaster?.Trigger();
            //}
        }

        public Blaster Blaster { get; set; }
        public int Value { get => 10; }
    }
}
