using SpaceInvaders.Core;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Models
{
    public class Bullet(Direction direction) : Rigidbody
    {
        private readonly int speed = direction == Direction.Down ? 7 : -7;
        private double movement = 0;

        public override void FixedUpdate()
        {
            Collider.Y += speed;
        }

        public override void Update(double deltaTime)
        {
            //movement += (speed * (deltaTime / 20.0f));
            //if (movement > 1) {
            //    int shift = (int)movement;
            //    Collider.Y += shift;
            //    movement -= shift;
            //}
        }

        protected override void Hit()
        {
            Destroy();
        }
    }
}
